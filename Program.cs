using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using F4BMS.Database;
using System.IO;



namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            /***************************************************************
             * The following tests can be used to check the functionality  *
             * of the Library.  Uncomment the lines for each area to check *
             * a specific function.  Make sure to supply the correct file  * 
             * name.  The second LOD test requires a FILE OFFSET in the    *
             * LOD File you want to load.  This can be found in the Header *
             * File under LODHeaders.  Database tests are passed an index  *
             * in the file to load in the second argument.                 *
             **************************************************************/

            /*
            F4BMS.LOD.LODFile lf = new F4BMS.LOD.LODFile("P:\\KOREAOBJ.LOD", "P:\\KOREAOBJ.HDR");
            List<F4BMS.LOD.LOD> LODs = new List<F4BMS.LOD.LOD>();
            LODs =  lf.FindLODType(F4BMS.LOD.NodeType.LightStringNode, true);            
            */            
            //************************** LOD Tests ************************/                        
            // To Load the Entire LOD File uncomment this section
            // ********* NOTE: Remember to change the Location of the Files you are reading from. ********
            { 
            /*
            F4BMS.LOD.LODFile lf = new F4BMS.LOD.LODFile("P:\\KOREAOBJ.LOD", "P:\\KOREAOBJ.HDR");
            Console.Write(lf.GetLOD(152).DebugPrint());
            lf.Save();
            Console.WriteLine("Done");
            */
            // To Test Loading a Single LOD from a position in the LOD file uncomment the following section
            // The Second Argument is the File Offset, which can be found in the HDR File.
            // ********* NOTE: Remember to change the Location of the Files you are reading from. ********

            /*
            F4BMS.LOD.LOD testLOD = new F4BMS.LOD.LOD("P:\\KoreaOBJ.LOD", 41107156);
            Console.Write(testLOD.DebugPrint());            
            */

            // To test the LOD Writing Function of the Library uncomment the following section
            // ********* NOTE: Remember to change the Location of the Files you are reading from. ********

            /*
            F4BMS.LOD.LOD testLOD = new F4BMS.LOD.LOD("P:\\KoreaOBJ.LOD", 519092216);
            //F4BMS.LOD.LOD testLOD = new F4BMS.LOD.LOD("P:\\KoreaOBJ.LOD", 102812);
            using (StreamWriter writer = new StreamWriter(File.Create("P:\\testlod.txt")))
            {
                writer.Write(testLOD.Print());
            }
            using (BinaryWriter writer= new BinaryWriter(File.Create("P:\\testlod.LOD")))
            {
                testLOD.Save(writer.BaseStream);
            }
            F4BMS.LOD.LOD testLOD1 = new F4BMS.LOD.LOD("P:\\testlod.LOD", 0);
            using (StreamWriter writer = new StreamWriter(File.Create("P:\\testlod1.txt")))
            {
                writer.Write(testLOD1.Print());
            }
            
            //Console.Write(testLOD.DebugPrint());
            */
            }
            /************************ Header File Tests *******************/
            {
                // Uncomment this section to read in the header file

                //F4BMS.Header.HeaderFile hf = new F4BMS.Header.HeaderFile("P:\\KoreaObj.HDR");
                //Console.WriteLine(hf.Headers[20].LODReferences[0].LODID);
                //Console.Write(hf.LODHeaderCount);           

                // Uncomment this section to test writing the Header File  
                /*
                F4BMS.Header.HeaderFile hf = new F4BMS.Header.HeaderFile("G:\\Falcon BMS 4.33 U1\\Data\\Terrdata\\objects\\KoreaObj.HDR");
                Console.WriteLine(hf.Headers[20].LODReferences[0].LODID);
                using (BinaryWriter writer = new BinaryWriter(File.Create("P:\\KoreaObj.HDR")))
                {
                    hf.Save(writer.BaseStream);
                }
                F4BMS.Header.HeaderFile hf1 = new F4BMS.Header.HeaderFile("P:\\KoreaObj.HDR");
                Console.WriteLine(hf1.Headers[20].LODReferences[0].LODID);
                */

                /*
                // Unaltered File Output
                Console.WriteLine("Initial File Size: " + hf.FileSize);

                Console.WriteLine("Colors: " + hf.ColorCount);
                Console.WriteLine("Dark Color Count: " + hf.DarkColorCount);
                for (int i = 0; i < 5; i++)
                {
                    Console.WriteLine("Color " + i + ": R:" + hf.Colors[i].R + " G:" + hf.Colors[i].G + " B:" + hf.Colors[i].B + " A:" + hf.Colors[i].R);
                }

                Console.WriteLine("Palettes: " + hf.PaletteCount);
                for (int i = 0; i < 5; i++)
                {
                    Console.WriteLine("Palette " + i);
                    for (int j = 0; j < 32; j++)
                    {
                        for (int k = 0; k < 8; k++)
                            Console.Write(hf.Palettes[i].Colors[8 * j + k].ToString() + " ");
                        Console.Write("\r\n");
                    }
                    Console.Write("\r\n");
                }

                Console.WriteLine("Textures: " + hf.TextureCount);

                Console.WriteLine("LOD Headers: " + hf.LODHeaderCount);
                for (int i = 0; i < 5; i++)
                {
                    Console.WriteLine("LOD Header " + i);
                    Console.WriteLine("LOD File OFfset: " + hf.LODHeaders[i].FileOffset);
                    Console.WriteLine("LOD File Size: " + hf.LODHeaders[i].FileSize);
                }

                Console.WriteLine("Parent Headers: " + hf.ParentCount);
                for (int i = 0; i < 5; i++)
                {
                    Console.WriteLine("Parent " + i);
                    Console.WriteLine("LOD Count: " + hf.Headers[i].LODCount);
                    Console.WriteLine("LOD Pointer: " + hf.Headers[i].LODRecordPointer);
                    Console.WriteLine("Slot Count: " + hf.Headers[i].SlotCount);
                    Console.WriteLine("Slot Pointer: " + hf.Headers[i].SlotPointer);
                    Console.WriteLine("Switch Count: " + hf.Headers[i].SwitchCount);
                }
                Console.Write("\r\n************************************\r\n");
                // Altered File Output
                F4BMS.Header.HeaderFile hf1 = new F4BMS.Header.HeaderFile("P:\\testhdr.HDR");
                Console.WriteLine("Saved File Size: " + hf1.FileSize);

                Console.WriteLine("Colors: " + hf1.ColorCount);
                Console.WriteLine("Dark Color Count: " + hf1.DarkColorCount);
                for (int i = 0; i < 5; i++)
                {
                    Console.WriteLine("Color " + i + ": R:" + hf1.Colors[i].R + " G:" + hf1.Colors[i].G + " B:" + hf1.Colors[i].B + " A:" + hf1.Colors[i].R);
                }

                Console.WriteLine("Palettes: " + hf1.PaletteCount);
                for (int i = 0; i < 5; i++)
                {
                    Console.WriteLine("Palette " + i);
                    for (int j = 0; j < 32; j++)
                    {
                        for (int k = 0; k < 8; k++)
                            Console.Write(hf1.Palettes[i].Colors[8 * j + k].ToString() + " ");
                        Console.Write("\r\n");
                    }
                    Console.Write("\r\n");
                }

                Console.WriteLine("Textures: " + hf1.TextureCount);

                Console.WriteLine("LOD Headers: " + hf1.LODHeaderCount);
                for (int i = 0; i < 5; i++)
                {
                    Console.WriteLine("LOD Header " + i);
                    Console.WriteLine("LOD File OFfset: " + hf1.LODHeaders[i].FileOffset);
                    Console.WriteLine("LOD File Size: " + hf1.LODHeaders[i].FileSize);
                }

                Console.WriteLine("Parent Headers: " + hf1.ParentCount);
                for (int i = 0; i < 5; i++)
                {
                    Console.WriteLine("Parent " + i);
                    Console.WriteLine("LOD Count: " + hf1.Headers[i].LODCount);
                    Console.WriteLine("LOD Pointer: " + hf1.Headers[i].LODRecordPointer);
                    Console.WriteLine("Slot Count: " + hf1.Headers[i].SlotCount);
                    Console.WriteLine("Slot Pointer: " + hf1.Headers[i].SlotPointer);
                    Console.WriteLine("Switch Count: " + hf1.Headers[i].SwitchCount);
                }
                */

            }
            /********************** Database Tests  ***********************/
            {
                string fname;
                ICTFile ctf;
                // Load the Class Table Database
                /*
                fname = "p:\\FALCON4.CT";
                // Individual Entry
                F4BMS.Database.ClassTable ct = new F4BMS.Database.ClassTable(fname);
                Console.Write(ct.Entries[17].Print());
                // Full File
                ctf = new ClassTable(fname);
                // XML Export      
                ctf.ToXML(fname + ".XML");
                */

                /*
                fname = "p:\\FALCON4.ACD";
                // Individual Entry
                F4BMS.Database.AircraftData ad = new F4BMS.Database.AircraftData(fname, 8);
                Console.Write(ad.Print());
                // Full File
                ctf = new AircraftDataFile(fname);
                // XML Export      
                ctf.ToXML(fname + ".XML");
                Console.Write(ctf.GetData()[3].Print());
                */

                /*
                fname = "p:\\FALCON4.VCD";
                // Individual Entry
                F4BMS.Database.VehicleData vd = new F4BMS.Database.VehicleData(fname, 8);
                Console.Write(vd.Print());
                // Full File
                ctf = new VehicleDataFile(fname);
                // XML Export      
                ctf.ToXML(fname + ".XML");
                */

                /*
                fname = "p:\\FALCON4.UCD";
                // Individual Entry
                F4BMS.Database.UnitData ud = new F4BMS.Database.UnitData(fname, 3);
                Console.Write(ud.Print());
                // Full File
                ctf = new UnitDataFile(fname);
                // XML Export      
                ctf.ToXML(fname + ".XML");
                */

                /*
                fname = "p:\\FALCON4.FCD";
                // Individual Entry
                F4BMS.Database.FeatureData fd = new F4BMS.Database.FeatureData(fname, 4);
                Console.Write(fd.Print());
                // Full File
                ctf = new FeatureDataFile(fname);
                // XML Export      
                ctf.ToXML(fname + ".XML");
                */

                /*
                fname = "p:\\FALCON4.FED";
                // Individual Entry
                F4BMS.Database.FeatureEntry fed = new F4BMS.Database.FeatureEntry(fname, 5);
                Console.Write(fed.Print());
                // Full File
                ctf = new FeatureEntryDataFile(fname);
                // XML Export      
                ctf.ToXML(fname + ".XML");
                */

                /*
                fname = "p:\\FALCON4.PD";
                // Individual Entry
                F4BMS.Database.PointData pd = new F4BMS.Database.PointData(fname, 8);
                Console.Write(pd.Print());
                // Full File
                ctf = new PointDataFile(fname);
                // XML Export      
                ctf.ToXML(fname + ".XML");
                */

                /*
                fname = "p:\\FALCON4.PDX";
                // Individual Entry
                F4BMS.Database.PointEXData pdx = new F4BMS.Database.PointEXData(fname, 4);
                Console.Write(pdx.Print());
                // Full File
                ctf = new PointEXDataFile(fname);
                // XML Export      
                ctf.ToXML(fname + ".XML");
                */

                /*
                fname = "p:\\FALCON4.PHD";
                // Individual Entry
                F4BMS.Database.PointHeaderData phd = new F4BMS.Database.PointHeaderData(fname, 8);
                Console.Write(phd.Print());
                // Full File
                ctf = new PointHeaderDataFile(fname);
                // XML Export      
                ctf.ToXML(fname + ".XML");
                */

                /*
                fname = "p:\\FALCON4.OCD";
                // Individual Entry
                F4BMS.Database.ObjectiveData ocd = new F4BMS.Database.ObjectiveData(fname, 8);
                Console.Write(ocd.Print());
                // Full File
                ctf = new ObjectiveDataFile(fname);
                // XML Export      
                ctf.ToXML(fname + ".XML");
                */

                /*
                fname = "p:\\FALCON4.WCD";
                // Individual Entry
                F4BMS.Database.WeaponData wd = new F4BMS.Database.WeaponData(fname, 8);
                Console.Write(wd.Print());
                // Full File
                ctf = new WeaponDataFile(fname);
                // XML Export      
                ctf.ToXML(fname + ".XML");
                */

                /*
                fname = "p:\\FALCON4.WLD";
                // Individual Entry
                F4BMS.Database.WeaponListData wld = new F4BMS.Database.WeaponListData(fname, 8);
                Console.Write(wld.Print());
                // Full File
                ctf = new WeaponListDataFile(fname);
                // XML Export      
                ctf.ToXML(fname + ".XML");
                */

                /*
                fname = "p:\\FALCON4.RCD";
                // Individual Entry
                F4BMS.Database.RadarData rcd = new F4BMS.Database.RadarData(fname, 8);
                Console.Write(rcd.Print());
                // Full File
                ctf = new RadarDataFile(fname);
                // XML Export      
                ctf.ToXML(fname + ".XML");
                */

                /*
                fname = "p:\\FALCON4.ICD";
                // Individual Entry
                F4BMS.Database.IRSensorData icd = new F4BMS.Database.IRSensorData(fname, 8);
                Console.Write(icd.Print());
                // Full File
                ctf = new IRSensorDataFile(fname);
                // XML Export      
                ctf.ToXML(fname + ".XML");
                */

                /*
                fname = "p:\\FALCON4.RWD";
                // Individual Entry
                F4BMS.Database.RWRData rwd = new F4BMS.Database.RWRData(fname, 8);
                Console.Write(rwd.Print());
                // Full File
                ctf = new RWRDataFile(fname);
                // XML Export      
                ctf.ToXML(fname + ".XML");
                */

                /*
                fname = "p:\\FALCON4.VSD";
                // Individual Entry
                F4BMS.Database.VisualSensorData vsd = new F4BMS.Database.VisualSensorData(fname, 8);
                Console.Write(vsd.Print());
                // Full File
                ctf = new VisualSensorDataFile(fname);
                // XML Export      
                ctf.ToXML(fname + ".XML");
                */

                /*
                fname = "p:\\FALCON4.SWD";
                // Individual Entry
                F4BMS.Database.SimWeaponsData swd = new F4BMS.Database.SimWeaponsData(fname, 8);
                Console.Write(swd.Print());
                // Full File
                ctf = new SimWeaponsDataFile(fname);
                // XML Export      
                ctf.ToXML(fname + ".XML");
                */

                /*
                fname = "p:\\FALCON4.SSD";
                // Individual Entry
                F4BMS.Database.SquadronStoresData ssd = new F4BMS.Database.SquadronStoresData(fname, 8);
                Console.Write(ssd.Print());
                // Full File
                ctf = new SquadronStoresDataFile(fname);
                // XML Export      
                ctf.ToXML(fname + ".XML");
                */

                /*
                fname = "p:\\FALCON4.RKT";
                // Individual Entry
                F4BMS.Database.RocketData rkt = new F4BMS.Database.RocketData(fname, 8);
                Console.Write(rkt.Print());
                // Full File
                ctf = new RocketDataFile(fname);
                // XML Export      
                ctf.ToXML(fname + ".XML");
                */
            }
            /************************ Key File Tests **********************/
            {
                /*
                F4BMS.KEYFILE.KeyFile keyfile = new F4BMS.KEYFILE.KeyFile("P:\\BMS - Full.key");
                keyfile.Save("P:\\test.key");
                */
            }
            
        }
    }
}
