using System;
using System.Buffers;
using System.Buffers.Binary;
using System.Collections.Generic;
using System.Text;

namespace FMWSaveManager.FileFormats
{
    internal class SaveHelper
    {
        public static List<T> ReadList<T>(ref Span<byte> byteSpan, bool isSteam)
        {
            ushort listSize = ReadUShort(ref byteSpan);
            List<T> objectList = new List<T>();

            if (typeof(T) == typeof(sbyte))
            {
                List<sbyte> objectListRef = (List<sbyte>)(object)objectList;
                for (ushort i = 0; i < listSize; i++)
                {
                    objectListRef.Add(ReadByte(ref byteSpan));
                }
            }
            else if (typeof(T) == typeof(byte))
            {
                List<byte> objectListRef = (List<byte>)(object)objectList;
                for (ushort i = 0; i < listSize; i++)
                {
                    objectListRef.Add(ReadUByte(ref byteSpan));
                }
            }
            else if (typeof(T) == typeof(short))
            {
                List<short> objectListRef = (List<short>)(object)objectList;
                for (ushort i = 0; i < listSize; i++)
                {
                    objectListRef.Add(ReadShort(ref byteSpan));
                }
            }
            else if (typeof(T) == typeof(ushort))
            {
                List<ushort> objectListRef = (List<ushort>)(object)objectList;
                for (ushort i = 0; i < listSize; i++)
                {
                    objectListRef.Add(ReadUShort(ref byteSpan));
                }
            }
            else if (typeof(T) == typeof(int))
            {
                List<int> objectListRef = (List<int>)(object)objectList;
                for (ushort i = 0; i < listSize; i++)
                {
                    objectListRef.Add(ReadInt(ref byteSpan));
                }
            }
            else if (typeof(T) == typeof(uint))
            {
                List<uint> objectListRef = (List<uint>)(object)objectList;
                for (ushort i = 0; i < listSize; i++)
                {
                    objectListRef.Add(ReadUInt(ref byteSpan));
                }
            }
            else if (typeof(T) == typeof(string))
            {
                List<string> objectListRef = (List<string>)(object)objectList;
                if (isSteam)
                {
                    for (ushort i = 0; i < listSize; i++)
                    {
                        objectListRef.Add(ReadStringSteam(ref byteSpan));
                    }
                }
                else
                {
                    for (ushort i = 0; i < listSize; i++)
                    {
                        objectListRef.Add(ReadStringDoujin(ref byteSpan));
                    }
                }
            }

            return objectList;
        }

        public static void WriteListBuffer<T>(ArrayBufferWriter<byte> byteBuffer, List<T> input)
        {
            ushort listSize = (ushort)input.Count;
            WriteUShortBuffer(byteBuffer, listSize);

            if (typeof(T) == typeof(sbyte))
            {
                List<sbyte> inputRef = (List<sbyte>)(object)input;
                for (ushort i = 0; i < listSize; i++)
                {
                    WriteByteBuffer(byteBuffer, inputRef[i]);
                }
            }
            else if (typeof(T) == typeof(byte))
            {
                List<byte> inputRef = (List<byte>)(object)input;
                for (ushort i = 0; i < listSize; i++)
                {
                    WriteUByteBuffer(byteBuffer, inputRef[i]);
                }
            }
            else if (typeof(T) == typeof(short))
            {
                List<short> inputRef = (List<short>)(object)input;
                for (ushort i = 0; i < listSize; i++)
                {
                    WriteShortBuffer(byteBuffer, inputRef[i]);
                }
            }
            else if (typeof(T) == typeof(ushort))
            {
                List<ushort> inputRef = (List<ushort>)(object)input;
                for (ushort i = 0; i < listSize; i++)
                {
                    WriteUShortBuffer(byteBuffer, inputRef[i]);
                }
            }
            else if (typeof(T) == typeof(int))
            {
                List<int> inputRef = (List<int>)(object)input;
                for (ushort i = 0; i < listSize; i++)
                {
                    WriteIntBuffer(byteBuffer, inputRef[i]);
                }
            }
            else if (typeof(T) == typeof(uint))
            {
                List<uint> inputRef = (List<uint>)(object)input;
                for (ushort i = 0; i < listSize; i++)
                {
                    WriteUIntBuffer(byteBuffer, inputRef[i]);
                }
            }
            else if (typeof(T) == typeof(string))
            {
                List<string> inputRef = (List<string>)(object)input;
                for (ushort i = 0; i < listSize; i++)
                {
                    WriteStringBuffer(byteBuffer, inputRef[i]);
                }
            }
        }

        public static List<List<T>> ReadGrid<T>(ref Span<byte> byteSpan, bool isSteam)
        {
            ushort gridWidth = ReadUShort(ref byteSpan);
            ushort gridHeight = ReadUShort(ref byteSpan);

            List<List<T>> objectGrid = new List<List<T>>(gridWidth);

            if (typeof(T) == typeof(sbyte))
            {

                for (ushort i = 0; i < gridWidth; i++)
                {
                    List<sbyte> row = new List<sbyte>(gridHeight);
                    for (ushort j = 0; j < gridHeight; j++)
                    {
                        row.Add(ReadByte(ref byteSpan));
                    }

                    objectGrid.Add((List<T>)(object)row);
                }
            }
            else if (typeof(T) == typeof(byte))
            {

                for (ushort i = 0; i < gridWidth; i++)
                {
                    List<byte> row = new List<byte>(gridHeight);
                    for (ushort j = 0; j < gridHeight; j++)
                    {
                        row.Add(ReadUByte(ref byteSpan));
                    }

                    objectGrid.Add((List<T>)(object)row);
                }
            }
            else if (typeof(T) == typeof(short))
            {
                for (ushort i = 0; i < gridWidth; i++)
                {
                    List<short> row = new List<short>(gridHeight);
                    for (ushort j = 0; j < gridHeight; j++)
                    {
                        row.Add(ReadShort(ref byteSpan));
                    }

                    objectGrid.Add((List<T>)(object)row);
                }
            }
            else if (typeof(T) == typeof(ushort))
            {
                for (ushort i = 0; i < gridWidth; i++)
                {
                    List<ushort> row = new List<ushort>(gridHeight);
                    for (ushort j = 0; j < gridHeight; j++)
                    {
                        row.Add(ReadUShort(ref byteSpan));
                    }

                    objectGrid.Add((List<T>)(object)row);
                }
            }
            else if (typeof(T) == typeof(int))
            {
                for (ushort i = 0; i < gridWidth; i++)
                {
                    List<int> row = new List<int>(gridHeight);
                    for (ushort j = 0; j < gridHeight; j++)
                    {
                        row.Add(ReadInt(ref byteSpan));
                    }

                    objectGrid.Add((List<T>)(object)row);
                }
            }
            else if (typeof(T) == typeof(uint))
            {
                for (ushort i = 0; i < gridWidth; i++)
                {
                    List<uint> row = new List<uint>(gridHeight);
                    for (ushort j = 0; j < gridHeight; j++)
                    {
                        row.Add(ReadUInt(ref byteSpan));
                    }

                    objectGrid.Add((List<T>)(object)row);
                }
            }
            else if (typeof(T) == typeof(string))
            {
                for (ushort i = 0; i < gridWidth; i++)
                {
                    List<string> row = new List<string>(gridHeight);
                    if (isSteam)
                    {
                        for (ushort j = 0; j < gridHeight; j++)
                        {
                            row.Add(ReadStringSteam(ref byteSpan));
                        }
                    }
                    else
                    {
                        for (ushort j = 0; j < gridHeight; j++)
                        {
                            row.Add(ReadStringDoujin(ref byteSpan));
                        }
                    }

                    objectGrid.Add((List<T>)(object)row);
                }
            }

            return objectGrid;
        }

        public static void WriteGridBuffer<T>(ArrayBufferWriter<byte> byteBuffer, List<List<T>> input)
        {
            ushort gridWidth = (ushort)input.Count;
            ushort gridHeight = (ushort)input[0].Count;

            WriteUShortBuffer(byteBuffer, gridWidth);
            WriteUShortBuffer(byteBuffer, gridHeight);

            if (typeof(T) == typeof(sbyte))
            {
                List<List<sbyte>> inputRef = (List<List<sbyte>>)(object)input;
                for (ushort i = 0; i < gridWidth; i++)
                {

                    for (ushort j = 0; j < gridHeight; j++)
                    {
                        WriteByteBuffer(byteBuffer, inputRef[i][j]);
                    }
                }
            }
            else if (typeof(T) == typeof(byte))
            {
                List<List<byte>> inputRef = (List<List<byte>>)(object)input;
                for (ushort i = 0; i < gridWidth; i++)
                {

                    for (ushort j = 0; j < gridHeight; j++)
                    {
                        WriteUByteBuffer(byteBuffer, inputRef[i][j]);
                    }
                }
            }
            else if (typeof(T) == typeof(short))
            {
                List<List<short>> inputRef = (List<List<short>>)(object)input;
                for (ushort i = 0; i < gridWidth; i++)
                {
                    for (ushort j = 0; j < gridHeight; j++)
                    {
                        WriteShortBuffer(byteBuffer, inputRef[i][j]);
                    }


                }
            }
            else if (typeof(T) == typeof(ushort))
            {
                List<List<ushort>> inputRef = (List<List<ushort>>)(object)input;
                for (ushort i = 0; i < gridWidth; i++)
                {
                    for (ushort j = 0; j < gridHeight; j++)
                    {
                        WriteUShortBuffer(byteBuffer, inputRef[i][j]);
                    }
                }
            }
            else if (typeof(T) == typeof(int))
            {
                List<List<int>> inputRef = (List<List<int>>)(object)input;
                for (ushort i = 0; i < gridWidth; i++)
                {
                    for (ushort j = 0; j < gridHeight; j++)
                    {
                        WriteIntBuffer(byteBuffer, inputRef[i][j]);
                    }
                }
            }
            else if (typeof(T) == typeof(uint))
            {
                List<List<uint>> inputRef = (List<List<uint>>)(object)input;
                for (ushort i = 0; i < gridWidth; i++)
                {
                    for (ushort j = 0; j < gridHeight; j++)
                    {
                        WriteUIntBuffer(byteBuffer, inputRef[i][j]);
                    }
                }
            }
            else if (typeof(T) == typeof(string))
            {
                List<List<string>> inputRef = (List<List<string>>)(object)input;
                for (ushort i = 0; i < gridWidth; i++)
                {
                    for (ushort j = 0; j < gridHeight; j++)
                    {
                        WriteStringBuffer(byteBuffer, inputRef[i][j]);
                    }
                }
            }
        }

        public static string ReadStringDoujin(ref Span<byte> byteSpan)
        {
            // Doujin read UTF-8 string
            uint stringLength = BinaryPrimitives.ReadUInt32LittleEndian(byteSpan);
            byteSpan = byteSpan.Slice(4);

            /* Cast uint stringLength as int should be fine
             * as spans cannot be bigger than the max 4-byte signed integer size
             * Will fail if slice goes beyond span max int length
             */
            string byteString = Encoding.UTF8.GetString(byteSpan.Slice(0, (int)stringLength));
            byteSpan = byteSpan.Slice((int)stringLength);
            return byteString;
        }

        public static string ReadStringSteam(ref Span<byte> byteSpan)
        {
            // Steam read UTF-8 string
            int nullByteIndex = byteSpan.IndexOf((byte)'\0');

            string byteString = Encoding.UTF8.GetString(byteSpan.Slice(0, nullByteIndex));
            byteSpan = byteSpan.Slice(nullByteIndex + 1);
            return byteString;
        }

        public static void WriteStringBuffer(ArrayBufferWriter<byte> byteBuffer, string input)
        {
            // Steam write UTF-8 string
            int stringByteLength = Encoding.UTF8.GetByteCount(input);

            Span<byte> byteSpan = byteBuffer.GetSpan(stringByteLength + 1);
            Encoding.UTF8.GetBytes(input + (char)0, byteSpan);
            byteBuffer.Advance(stringByteLength + 1);
        }

        public static sbyte ReadByte(ref Span<byte> byteSpan)
        {
            sbyte byteUnit = (sbyte)byteSpan[0];
            byteSpan = byteSpan.Slice(1);
            return byteUnit;
        }

        public static void WriteByteBuffer(ArrayBufferWriter<byte> byteBuffer, sbyte input)
        {
            Span<byte> byteSpan = byteBuffer.GetSpan(1);
            byteSpan[0] = (byte)input;
            byteBuffer.Advance(1);
        }

        public static byte ReadUByte(ref Span<byte> byteSpan)
        {
            byte byteUnit = byteSpan[0];
            byteSpan = byteSpan.Slice(1);
            return byteUnit;
        }

        public static void WriteUByteBuffer(ArrayBufferWriter<byte> byteBuffer, byte input)
        {
            Span<byte> byteSpan = byteBuffer.GetSpan(1);
            byteSpan[0] = input;
            byteBuffer.Advance(1);
        }

        public static short ReadShort(ref Span<byte> byteSpan)
        {
            short shortUnit = BinaryPrimitives.ReadInt16LittleEndian(byteSpan);
            byteSpan = byteSpan.Slice(2);
            return shortUnit;
        }

        public static void WriteShortBuffer(ArrayBufferWriter<byte> byteBuffer, short input)
        {
            Span<byte> byteSpan = byteBuffer.GetSpan(2);
            BinaryPrimitives.WriteInt16LittleEndian(byteSpan, input);
            byteBuffer.Advance(2);
        }

        public static ushort ReadUShort(ref Span<byte> byteSpan)
        {
            ushort shortUnit = BinaryPrimitives.ReadUInt16LittleEndian(byteSpan);
            byteSpan = byteSpan.Slice(2);
            return shortUnit;
        }

        public static void WriteUShortBuffer(ArrayBufferWriter<byte> byteBuffer, ushort input)
        {
            Span<byte> byteSpan = byteBuffer.GetSpan(2);
            BinaryPrimitives.WriteUInt16LittleEndian(byteSpan, input);
            byteBuffer.Advance(2);
        }

        public static int ReadInt(ref Span<byte> byteSpan)
        {
            int intUnit = BinaryPrimitives.ReadInt32LittleEndian(byteSpan);
            byteSpan = byteSpan.Slice(4);
            return intUnit;
        }

        public static void WriteIntBuffer(ArrayBufferWriter<byte> byteBuffer, int input)
        {
            Span<byte> byteSpan = byteBuffer.GetSpan(4);
            BinaryPrimitives.WriteInt32LittleEndian(byteSpan, input);
            byteBuffer.Advance(4);
        }

        public static uint ReadUInt(ref Span<byte> byteSpan)
        {
            uint intUnit = BinaryPrimitives.ReadUInt32LittleEndian(byteSpan);
            byteSpan = byteSpan.Slice(4);
            return intUnit;
        }

        public static void WriteUIntBuffer(ArrayBufferWriter<byte> byteBuffer, uint input)
        {
            Span<byte> byteSpan = byteBuffer.GetSpan(4);
            BinaryPrimitives.WriteUInt32LittleEndian(byteSpan, input);
            byteBuffer.Advance(4);
        }

        public static float ReadFloat(ref Span<byte> byteSpan)
        {
            float floatUnit = BinaryPrimitives.ReadSingleLittleEndian(byteSpan);
            byteSpan = byteSpan.Slice(4);
            return floatUnit;
        }

        public static void WriteFloatBuffer(ArrayBufferWriter<byte> byteBuffer, float input)
        {
            Span<byte> byteSpan = byteBuffer.GetSpan(4);
            BinaryPrimitives.WriteSingleLittleEndian(byteSpan, input);
            byteBuffer.Advance(4);
        }

        public static double ReadDouble(ref Span<byte> byteSpan)
        {
            double doubleUnit = BinaryPrimitives.ReadDoubleLittleEndian(byteSpan);
            byteSpan = byteSpan.Slice(8);
            return doubleUnit;
        }

        public static void WriteDoubleBuffer(ArrayBufferWriter<byte> byteBuffer, double input)
        {
            Span<byte> byteSpan = byteBuffer.GetSpan(8);
            BinaryPrimitives.WriteDoubleLittleEndian(byteSpan, input);
            byteBuffer.Advance(8);
        }
    }
}
