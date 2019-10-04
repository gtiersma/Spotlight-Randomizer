﻿using Syroot.BinaryData;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using static BYAML.ByamlFile;

namespace BYAML
{
    public class ByamlIterator : ByamlReader
    {
        public struct DictionaryEntry
        {
            public string Key { get; private set; }

            private ByamlIterator _iterator;
            public long Position { get; private set; }
            public ByamlNodeType NodeType { get; private set; }

            internal DictionaryEntry(ByamlIterator iterator, (string, ByamlNodeType, long) entry)
            {
                Key = entry.Item1;
                _iterator = iterator;
                Position = entry.Item3;
                NodeType = entry.Item2;
            }

            public dynamic Parse()
            {
                if (_iterator._alreadyReadNodes.ContainsKey((uint)Position))
                    return _iterator._alreadyReadNodes[(uint)Position];

                _iterator._binaryStream.Position = Position;
                return _iterator.ReadNodeValue(_iterator._binaryStream, NodeType);
            }

            public IEnumerable<DictionaryEntry> IterDictionary()
            {
                _iterator._binaryStream.Position = Position;
                uint lengthAndType = _iterator._binaryStream.ReadUInt32();

                if (NodeType != ByamlNodeType.Dictionary)
                    throw new Exception("This entry is not a Dictionary");

                foreach ((string, ByamlNodeType, long) entry in _iterator.IterDictionaryNode(
                        _iterator._binaryStream, (int)_iterator.Get3LsbBytes(lengthAndType))
                    )
                    yield return new DictionaryEntry(_iterator, entry);
            }

            public IEnumerable<ArrayEntry> IterArray()
            {
                _iterator._binaryStream.Position = Position;
                uint length = _iterator._binaryStream.ReadUInt32();

                if (NodeType != ByamlNodeType.Array)
                    throw new Exception("This entry is not an Array");

                foreach ((int, ByamlNodeType, long) entry in _iterator.IterArrayNode(
                        _iterator._binaryStream, (int)_iterator.Get3LsbBytes(length))
                    )
                    yield return new ArrayEntry(_iterator, entry);
            }
        }

        public struct ArrayEntry
        {
            public int Index { get; private set; }

            private ByamlIterator _iterator;
            public long Position { get; private set; }
            public ByamlNodeType NodeType { get; private set; }

            internal ArrayEntry(ByamlIterator iterator, (int, ByamlNodeType, long) entry)
            {
                Index = entry.Item1;
                _iterator = iterator;
                Position = entry.Item3;
                NodeType = entry.Item2;
            }

            public dynamic Parse()
            {
                _iterator._binaryStream.Position = Position;
                return _iterator.ReadNodeValue(_iterator._binaryStream, NodeType);
            }

            public IEnumerable<DictionaryEntry> IterDictionary()
            {
                _iterator._binaryStream.Position = Position;
                uint length = _iterator._binaryStream.ReadUInt32();

                if (NodeType != ByamlNodeType.Dictionary)
                    throw new Exception("This entry is not a Dictionary");

                foreach ((string, ByamlNodeType, long) entry in _iterator.IterDictionaryNode(
                        _iterator._binaryStream, (int)_iterator.Get3LsbBytes(length))
                    )
                    yield return new DictionaryEntry(_iterator, entry);
            }

            public IEnumerable<ArrayEntry> IterArray()
            {
                _iterator._binaryStream.Position = Position;
                uint length = _iterator._binaryStream.ReadUInt32();

                if (NodeType != ByamlNodeType.Array)
                    throw new Exception("This entry is not an Array");

                foreach ((int, ByamlNodeType, long) entry in _iterator.IterArrayNode(
                        _iterator._binaryStream, (int)_iterator.Get3LsbBytes(length))
                    )
                    yield return new ArrayEntry(_iterator, entry);
            }
        }
        
        bool _isClosed = false;

        public ByamlIterator(Stream stream, Endian byteOrder = Endian.Little, ushort version = 3, bool fastLoad = true)
            : base(stream, false, byteOrder, version, fastLoad)
        {
            _binaryStream = new BinaryStream(stream, ByteConverter.GetConverter(byteOrder));
        }

        public IEnumerable<DictionaryEntry> IterRootDictionary()
        {
            if (_isClosed)
                throw new Exception("Can't iterate more than once");

            using (_binaryStream)
            {

                if (!TryStartLoading())
                    yield break;

                uint lengthAndType = _binaryStream.ReadUInt32();

                if ((ByamlNodeType)Get1MsbByte(lengthAndType) != ByamlNodeType.Dictionary)
                    throw new Exception("Root is not a Dictionary");

                foreach ((string, ByamlNodeType, long) entry in IterDictionaryNode(_binaryStream, (int)Get3LsbBytes(lengthAndType)))
                    yield return new DictionaryEntry(this, entry);
            }
        }

        public IEnumerable<ArrayEntry> IterRootArray()
        {
            if (_isClosed)
                throw new Exception("Can't iterate more than once");

            using (_binaryStream)
            {
                if (!TryStartLoading())
                    yield break;

                uint lengthAndType = _binaryStream.ReadUInt32();

                if ((ByamlNodeType)Get1MsbByte(lengthAndType) != ByamlNodeType.Array)
                    throw new Exception("Root is not an Array");

                foreach ((int, ByamlNodeType, long) entry in IterArrayNode(_binaryStream, (int)Get3LsbBytes(lengthAndType)))
                    yield return new ArrayEntry(this, entry);

                _isClosed = true;
            }
        }


        private IEnumerable<(int, ByamlNodeType, long)> IterArrayNode(BinaryStream binaryStream, int length, uint offset = 0)
        {
            // Read the element types of the array.
            byte[] nodeTypes = binaryStream.ReadBytes(length);
            // Read the elements, which begin after a padding to the next 4 bytes.
            binaryStream.Align(4);
            for (int i = 0; i < length; i++)
            {
                long pos = binaryStream.Position;
                ByamlNodeType nodeType = (ByamlNodeType)nodeTypes[i];
                if (IsReferenceType(nodeType))
                    yield return (i, nodeType, binaryStream.ReadUInt32());
                else
                    yield return (i, nodeType, pos);

                binaryStream.Position = pos + 4;
            }
        }

        private IEnumerable<(string, ByamlNodeType, long)> IterDictionaryNode(BinaryStream binaryStream, int length, uint offset = 0)
        {
            // Read the elements of the dictionary.
            for (int i = 0; i < length; i++)
            {
                uint indexAndType = binaryStream.ReadUInt32();
                int nodeNameIndex = (int)Get3MsbBytes(indexAndType);
                ByamlNodeType nodeType = (ByamlNodeType)Get1LsbByte(indexAndType);
                string nodeName = _nameArray[nodeNameIndex];

                long pos = binaryStream.Position;

                if (IsReferenceType(nodeType))
                    yield return (nodeName, nodeType, binaryStream.ReadUInt32());
                else
                    yield return (nodeName, nodeType, pos);

                binaryStream.Position = pos + 4;
            }
        }
    }
}
