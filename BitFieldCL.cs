using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Client
{
    public class BitFieldCL
    {
        String BitData;
        public BitFieldCL(UInt64 Data)
        {
            BitField Bits = new BitField();

 
            try
            {
                Bits.Mask = Data;
            }
            catch
            {
                MessageBox.Show("Error");
                return;
            }
            BitData = CompleteBit(Bits.ToStringBin(), 64);
        }

        public string ToString(Int32 Base)
        {
            byte[] Temp = Encoding.ASCII.GetBytes(BitData);
            Array.Reverse(Temp);
            String STemp = Encoding.ASCII.GetString(Temp);
            STemp = STemp.Substring(0, Base);

            Temp = Encoding.ASCII.GetBytes(STemp);
            Array.Reverse(Temp);
            STemp = Encoding.ASCII.GetString(Temp);

            return STemp;
        }

        public byte Bit(Int32 Index)
        {
            byte[] Temp = Encoding.ASCII.GetBytes(BitData);
            Array.Reverse(Temp);
            return Temp[Index];
        }

        public byte[] BitField()
        {
            byte[] Temp = Encoding.ASCII.GetBytes(BitData);
            for (int i = 0; i < Temp.Length; i++)
            {
                byte T = Temp[i];
                Temp[i] = byte.Parse(Convert.ToChar(T).ToString());
            }

            Array.Reverse(Temp);
            return Temp;
        }

        private static String CompleteBit(String Data, Int32 LengD)
        {

            if (Data.Length < LengD)
            {
                for (int i = 1; i <= LengD; i++)
                {
                    Data = "0" + Data;
                    if (Data.Length == LengD)
                    {
                        break;
                    }
                }
            }
            if (Data.Length > LengD)
            {
                MessageBox.Show("Error Bit");
            }

            return Data;
        }
    }


    /// <summary>
    /// The BisField class exposes the following methods:
    ///	Initialization:
    ///		BitField()		// Constructor
    ///		ClearField()	// ClearField clears all contents of the Field
    ///		FillField()		// FillField fills all contents of the Field
    ///		SetField()		// Setting the specified flag and turning all other flags off.
    /// 
    /// Operations:
    ///		SetOn()			// Setting the specified flag and leaving all other flags unchanged
    ///		SetOff()		// Unsetting the specified flag and leaving all other flags unchanged.
    ///		SetToggle()		// Toggling the specified flag and leaving all other bits unchanged.
    ///		IsOn			// IsOn checks if the specified flag is set/on in the Field.
    ///		
    ///	Conversion:
    ///		DecimalToFlag	// Convert a decimal value to a Flag FlagsAttribute value.
    ///		ToStringDec()	// Return a string representation of the Field in decimal (base 10) notation
    ///		ToStringHex()	// Return a string representation of the Field in hexidecimal (base 16) notation.
    ///		ToStringBin()	// Return a string representation of the Field in binary (base 2) notation.
    /// </summary>
    class BitField
    {
        /// <summary>
        /// The FlagsAttribute indicates that an enumeration can be treated
        /// as a bit field; that is, a mask comprised of a set of flags.
        /// </summary>
        /// <remarks>
        /// - Bit fields can be combined using a bitwise OR operation, whereas enumerated constants cannot.
        ///		This means that the results from bitwise operations are also bit fields
        /// - Bit fields are generally used for lists of elements that might occur in combination,
        ///		whereas enumeration constants are generally used for lists of mutually exclusive elements.
        ///		Therefore, bit fields are designed to be combined to generate
        ///		unnamed values, whereas enumerated constants are not. Languages vary in their use of bit 
        ///		fields compared to enumeration constants.
        /// - The ulong keyword denotes a simple type that stores a 64-bit unsigned integer
        ///		so we can have up to a maximum of 64 unique flags with one enumeration of this type.
        /// </remarks>
        /// <example>
        /// The clear flag is enumerated to zero, and used appropriately can be used clear the Field.
        /// </example>
        [FlagsAttribute]
        public enum Flag : ulong
        {					// Hexidecimal		Decimal		Binary
            Clear = 0x00,	// 0x...0000		0			...00000000000000000
            f1 = 0x01,		// 0x...0001		1			...00000000000000001			
            f2 = f1 << 1,	// 0x...0002		2			...00000000000000010
            f3 = f2 << 1,	// 0x...0004		4			...00000000000000100
            f4 = f3 << 1,	// 0x...0008		8			...00000000000001000
            f5 = f4 << 1,	// 0x...0010		16			...00000000000010000
            f6 = f5 << 1,	// 0x...0020		32			...00000000000100000
            f7 = f6 << 1,	// 0x...0040		64			...00000000001000000
            f8 = f7 << 1,	// 0x...0080		128			...00000000010000000
            f9 = f8 << 1,	// 0x...0100		256			...00000000100000000
            f10 = f9 << 1,	// 0x...0200		512			...00000001000000000
            f11 = f10 << 1,	// 0x...0400		1024		...00000010000000000
            f12 = f11 << 1,	// 0x...0800		2048		...00000100000000000
            f13 = f12 << 1,	// 0x...1000		4096		...00001000000000000
            f14 = f13 << 1,	// 0x...2000		8192		...00010000000000000
            f15 = f14 << 1,	// 0x...4000		16384		...00100000000000000
            f16 = f15 << 1,	// 0x...8000		32768		...01000000000000000
            f17 = f16 << 1, f18 = f17 << 1, f19 = f18 << 1, f20 = f19 << 1,
            f21 = f20 << 1, f22 = f21 << 1, f23 = f22 << 1, f24 = f23 << 1,
            f25 = f24 << 1, f26 = f25 << 1, f27 = f26 << 1, f28 = f27 << 1,
            f29 = f28 << 1, f30 = f29 << 1, f31 = f30 << 1, f32 = f31 << 1,
            f33 = f32 << 1, f34 = f33 << 1, f35 = f34 << 1, f36 = f35 << 1,
            f37 = f36 << 1, f38 = f37 << 1, f39 = f38 << 1, f40 = f39 << 1,
            f41 = f40 << 1, f42 = f41 << 1, f43 = f42 << 1, f44 = f43 << 1,
            f45 = f44 << 1, f46 = f45 << 1, f47 = f46 << 1, f48 = f47 << 1,
            f49 = f48 << 1, f50 = f49 << 1, f51 = f50 << 1, f52 = f51 << 1,
            f53 = f52 << 1, f54 = f53 << 1, f55 = f54 << 1, f56 = f55 << 1,
            f57 = f56 << 1, f58 = f57 << 1, f59 = f58 << 1, f60 = f59 << 1,
            f61 = f60 << 1, f62 = f61 << 1, f63 = f62 << 1, f64 = f63 << 1
        };

        /// <summary>
        /// The Field that will store our 64 flags
        /// </summary>
        private ulong _Mask;

        /// <summary>
        /// Public property SET and GET to access the Field
        /// </summary>
        public ulong Mask
        {
            get
            {
                return _Mask;
            }
            set
            {
                _Mask = value;
            }
        }

        /// <summary>
        /// Contructor
        /// Add all initialization here
        /// </summary>
        public BitField()
        {
            ClearField();
        }

        /// <summary>
        /// ClearField clears all contents of the Field
        /// Set all bits to zero using the clear flag
        /// </summary>
        public void ClearField()
        {
            SetField(Flag.Clear);
        }

        /// <summary>
        /// FillField fills all contents of the Field
        /// Set all bits to zero using the negation of clear
        /// </summary>
        public void FillField()
        {
            SetField(~Flag.Clear);
        }

        /// <summary>
        /// Setting the specified flag(s) and turning all other flags off.
        ///  - Bits that are set to 1 in the flag will be set to one in the Field.
        ///  - Bits that are set to 0 in the flag will be set to zero in the Field. 
        /// </summary>
        /// <param name="flg">The flag to set in Field</param>
        private void SetField(Flag flg)
        {
            Mask = (ulong)flg;
        }

        /// <summary>
        /// Setting the specified flag(s) and leaving all other flags unchanged.
        ///  - Bits that are set to 1 in the flag will be set to one in the Field.
        ///  - Bits that are set to 0 in the flag will be unchanged in the Field. 
        /// </summary>
        /// <example>
        /// OR truth table
        /// 0 | 0 = 0
        /// 1 | 0 = 1
        /// 0 | 1 = 1
        /// 1 | 1 = 1
        /// </example>
        /// <param name="flg">The flag to set in Field</param>
        public void SetOn(Flag flg)
        {
            Mask |= (ulong)flg;
        }

        /// <summary>
        /// Unsetting the specified flag(s) and leaving all other flags unchanged.
        ///  - Bits that are set to 1 in the flag will be set to zero in the Field.
        ///  - Bits that are set to 0 in the flag will be unchanged in the Field. 
        /// </summary>
        /// <example>
        /// AND truth table
        /// 0 & 0 = 0
        /// 1 & 0 = 0
        /// 0 & 1 = 0
        /// 1 & 1 = 1
        /// </example>
        /// <param name="flg">The flag(s) to unset in Field</param>
        public void SetOff(Flag flg)
        {
            Mask &= ~(ulong)flg;
        }

        /// <summary>
        /// Toggling the specified flag(s) and leaving all other bits unchanged.
        ///  - Bits that are set to 1 in the flag will be toggled in the Field. 
        ///  - Bits that are set to 0 in the flag will be unchanged in the Field. 
        /// </summary>
        /// <example>
        /// XOR truth table
        /// 0 ^ 0 = 0
        /// 1 ^ 0 = 1
        /// 0 ^ 1 = 1
        /// 1 ^ 1 = 0
        /// </example>
        /// <param name="flg">The flag to toggle in Field</param>
        public void SetToggle(Flag flg)
        {
            Mask ^= (ulong)flg;
        }

        /// <summary>
        /// AnyOn checks if any of the specified flag are set/on in the Field.
        /// </summary>
        /// <param name="flg">flag(s) to check</param>
        /// <returns>
        /// true if flag is set in Field
        /// false otherwise
        /// </returns>
        public bool AnyOn(Flag flg)
        {
            return (Mask & (ulong)flg) != 0;
        }

        /// <summary>
        /// AllOn checks if all the specified flags are set/on in the Field.
        /// </summary>
        /// <param name="flg">flag(s) to check</param>
        /// <returns>
        /// true if all flags are set in Field
        /// false otherwise
        /// </returns>
        public bool AllOn(Flag flg)
        {
            return (Mask & (ulong)flg) == (ulong)flg;
        }

        /// <summary>
        /// IsEqual checks if all the specified flags are the same as in the Field.
        /// </summary>
        /// <param name="flg">flag(s) to check</param>
        /// <returns>
        /// true if all flags identical in the Field
        /// false otherwise
        /// </returns>
        public bool IsEqual(Flag flg)
        {
            return Mask == (ulong)flg;
        }


        /// <summary>
        /// Convert a decimal value to a Flag FlagsAttribute value.
        /// Method is thread safe
        /// </summary>
        /// <param name="dec">Valid input: dec between 0,64 </param>
        /// <returns></returns>
        public static Flag DecimalToFlag(decimal dec)
        {
            Flag flg = Flag.Clear;
            ulong tMsk = 0;
            byte shift;
            try
            {
                shift = (byte)dec;
                if (shift > 0 && shift <= 64)
                {
                    tMsk = (ulong)0x01 << (shift - 1);
                }
                flg = (Flag)tMsk;
            }
            catch (OverflowException e)		//Byte cast operation
            {
                Console.WriteLine("Exception caught in ToStringBin: {0}", e.ToString());
            }

            return flg;
        }

        /// <summary>
        /// Return a string representation of the Field in
        /// decimal (base10) notation.
        /// </summary>
        public String ToStringDec()
        {
            String sRet = "";
            try
            {
                sRet = String.Format("{0}", Mask);	//long
            }
            catch (ArgumentNullException e)	//Format
            {
                Console.WriteLine("Exception caught in ToStringDec: {0}", e.ToString());
            }
            catch (FormatException e)		//Format
            {
                Console.WriteLine("Exception caught in ToStringDec: {0}", e.ToString());
            }

            return sRet;
        }

        /// <summary>
        /// Return a string representation of the Field in
        /// hexidecimal (base16) notation.
        /// </summary>
        public String ToStringHex()
        {
            String sRet = "";
            try
            {
                sRet = String.Format("{0:x8}", Mask);		//hex
            }
            catch (ArgumentNullException e)	//Format & Convert
            {
                Console.WriteLine("Exception caught in ToStringHex: {0}", e.ToString());
            }
            catch (FormatException e)		//Format & Convert
            {
                Console.WriteLine("Exception caught in ToStringHex: {0}", e.ToString());
            }
            return sRet;
        }

        /// <summary>
        /// Return a string representation of the Field in
        /// binary (base2) notation.
        /// </summary>
        public String ToStringBin()
        {
            String sRet = "";
            try
            {
                // Convert converts a base data type to another base data type
                // Convert does not have a method for ulong, cast to long
                // which is still 64-bit.
                sRet = System.Convert.ToString((long)Mask, 2);			//binary
            }
            catch (InvalidCastException e)	//Convert
            {
                Console.WriteLine("Exception caught in ToStringBin: {0}", e.ToString());
            }
            catch (OverflowException e)		//Convert
            {
                Console.WriteLine("Exception caught in ToStringBin: {0}", e.ToString());
            }
            catch (ArgumentNullException e)	//Format & Convert
            {
                Console.WriteLine("Exception caught in ToStringBin: {0}", e.ToString());
            }
            catch (FormatException e)		//Format & Convert
            {
                Console.WriteLine("Exception caught in ToStringBin: {0}", e.ToString());
            }

            return sRet;
        }

    }
}
