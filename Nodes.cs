
using System;
using System.Collections.Generic;
using System.IO;
using F4BMS.LOD.Polys;
using System.Runtime.InteropServices;
using System.Linq;

namespace F4BMS.LOD.Nodes
{
    #region Enums
    /// <summary>
    /// Transform Types available to a Transform Node.
    /// </summary>
    [Guid("6E0712AA-1E26-40E7-9DF8-0313897E58D7")]
    public enum TransformType
    {
        /// <summary>
        /// Normal Transformation based on Vector Multiplication.
        /// </summary>
        Normal = 0,
        /// <summary>
        /// Render to Target Transformation based on Vector Multiplication.
        /// </summary>
        Billboard,
        /// <summary>
        /// Expansion based Transformation algorithm.
        /// </summary>
        Tree
    };
    /// <summary>
    /// Enumerates the Bit Mask VFT Field to identify the Type of Node being Processed.
    /// </summary>
    [Guid("C1674CB6-0DB4-4995-BA3D-61525A40B5A8")]
    public enum VFT
    {
        /// <summary>
        /// BNode VFT Entry
        /// </summary>
        BNode = 4608200,
        /// <summary>
        /// SubTreeNode VFT Entry
        /// </summary>
        SubTreeNode = 4608312,
        /// <summary>
        /// RootNode VFT Entry
        /// </summary>
        RootNode = 4608360,
        /// <summary>
        /// SlotNode VFT Entry
        /// </summary>
        SlotNode = 4608184,
        /// <summary>
        /// DOFNode VFT Entry
        /// </summary>
        DOFNode = 4608344,
        /// <summary>
        /// SwitchNode VFT Entry
        /// </summary>
        SwitchNode = 4608328,
        /// <summary>
        /// SplitNode VFT Entry
        /// </summary>
        SplitNode = 4608296,
        /// <summary>
        /// PrimitiveNode VFT Entry
        /// </summary>
        PrimitiveNode = 4608216,
        /// <summary>
        /// LitPrimitiveNode VFT Entry
        /// </summary>
        LitPrimitiveNode = 4608264,
        /// <summary>
        /// CulledPrimitiveNode VFT Entry
        /// </summary>
        CulledPrimitiveNode = 4608280,
        /// <summary>
        /// SpecialTransformNode VFT Entry
        /// </summary>
        SpecialTransformNode = 4608248,
        /// <summary>
        /// LightStringNode VFT Entry
        /// </summary>
        LightStringNode = 4608232,
        /// <summary>
        /// TransNode VFT Entry
        /// </summary>
        TransNode = 12,
        /// <summary>
        /// ScaleNode VFT Entry
        /// </summary>
        ScaleNode,
        /// <summary>
        /// XDOFNode VFT Entry
        /// </summary>
        XDOFNode,
        /// <summary>
        /// XSwitchNode VFT Entry
        /// </summary>
        XSWirchNode,
        /// <summary>
        /// RenderControlNode VFT Entry
        /// </summary>
        RenderControlNode,
        /// <summary>
        /// CullNode VFT Entry
        /// </summary>
        CullNode,
        /// <summary>
        /// PolyBucket VFT Entry
        /// </summary>
        PolyBucketNode
    }
    /// <summary>
    /// Enumeration of the DOF IDs in a complex Model
    /// </summary>
    [Guid("7F5205AF-0533-4E71-945D-BC3B0609D774")]
    public enum DOFID
    {
        /// <summary>
        /// Left Stab
        /// </summary>
        LeftStab,
        /// <summary>
        /// Right Stab
        /// </summary>
        RightStab,
        /// <summary>
        /// Left Aileron
        /// </summary>
        LeftAileron,
        /// <summary>
        /// Right Aileron
        /// </summary>
        RightAileron,
        /// <summary>
        /// Rudder
        /// </summary>
        Rudder,
        /// <summary>
        /// Nose Gear Rotation
        /// </summary>
        NoseGearRotate,
        /// <summary>
        /// Nose Gear Compression
        /// </summary>
        NoseGearCompress,
        /// <summary>
        /// Left Gear Compression
        /// </summary>
        LeftGearCompress,
        /// <summary>
        /// Right Gear Compression
        /// </summary>
        RightGearCompress,
        /// <summary>
        /// Left Leading Edge Flap
        /// </summary>
        LeftLEF,
        /// <summary>
        /// Right Leading Edge Flap
        /// </summary>
        RightLEF,
        /// <summary>
        /// Broken Nose Gear
        /// </summary>
        BrokenNoseGear,
        /// <summary>
        /// Broken Left Main Gear
        /// </summary>
        BrokenLeftGear,
        /// <summary>
        /// Broken Right Main Gear
        /// </summary>
        BrokenRightGear,
        /// <summary>
        /// Unused Entry
        /// </summary>
        NotUsed,
        /// <summary>
        /// Upper Left airbrake
        /// </summary>
        UpperLeftAirbrake,
        /// <summary>
        /// Lower Left Airbrake
        /// </summary>
        LowerLeftAirbrake,
        /// <summary>
        /// Upper Right Airbrake
        /// </summary>
        UpperRightAirbrake,
        /// <summary>
        /// Lower Right Airbrake
        /// </summary>
        LowerRightAirbrake,
        /// <summary>
        /// Nose Landing Gear
        /// </summary>
        NoseLandingGear,
        /// <summary>
        /// Left Main Landing Gear
        /// </summary>
        LeftLandingGear,
        /// <summary>
        /// Right Main Landing Gear
        /// </summary>
        RightLandingGear,
        /// <summary>
        /// Nose Gear Door
        /// </summary>
        NoseGearDoor,
        /// <summary>
        /// Left Main Gear Door
        /// </summary>
        LeftMainGearDoor,
        /// <summary>
        /// Right Main Gear Door
        /// </summary>
        RightMainGearDoor,
        /// <summary>
        /// Unused
        /// </summary>
        NotAvailable1,
        /// <summary>
        /// Unused
        /// </summary>
        NotAvailable2,
        /// <summary>
        /// Unused
        /// </summary>
        NotAvailable3,
        /// <summary>
        /// Left Flap
        /// </summary>
        LeftFlap,
        /// <summary>
        /// Right Flap
        /// </summary>
        RightFlap,
        /// <summary>
        /// Canopy
        /// </summary>
        Canopy,
        /// <summary>
        /// Complex Propeller 1
        /// </summary>
        ComplexPropeller1,
        /// <summary>
        /// Complex Propeller 2
        /// </summary>
        ComplexPropeller2,
        /// <summary>
        /// Complex Propeller 3
        /// </summary>
        ComplexPropeller3,
        /// <summary>
        /// Complex Propeller 4
        /// </summary>
        ComplexPropeller4,
        /// <summary>
        /// Complex Propeller 5
        /// </summary>
        ComplexPropeller5,
        /// <summary>
        /// Complex Propeller 6
        /// </summary>
        ComplexPropeller6,
        /// <summary>
        /// Tail hook
        /// </summary>
        TailHook,
        /// <summary>
        /// Afterburner
        /// </summary>
        Afterburner,
        /// <summary>
        /// Exhaust Nozzle
        /// </summary>
        ExhaustNozzle,
        /// <summary>
        /// Basic Propeller 1
        /// </summary>
        Propeller1,
        /// <summary>
        /// Basic Propeller 2
        /// </summary>
        Propeller2,
        /// <summary>
        /// Left Spoiler 1
        /// </summary>
        LeftSpoiler1,
        /// <summary>
        /// Right Spoiler 1
        /// </summary>
        RightSpoiler1,
        /// <summary>
        /// Left Spoiler 2
        /// </summary>
        LeftSpoiler2,
        /// <summary>
        /// Right Spoiler 2
        /// </summary>
        RightSpoiler2,
        /// <summary>
        /// Swing Wing 1
        /// </summary>
        SwingWing1,
        /// <summary>
        /// Swing Wing 2
        /// </summary>
        SwingWing2,
        /// <summary>
        /// Swing Wing 3
        /// </summary>
        SwingWing3,
        /// <summary>
        /// Swing Wing 4
        /// </summary>
        SwingWing4,
        /// <summary>
        /// Wheel Rotation 1
        /// </summary>
        WheelRotation1,
        /// <summary>
        /// Wheel Rotation 2
        /// </summary>
        WheelRotation2,
        /// <summary>
        /// Wheel Rotation 3
        /// </summary>
        WheelRotation3,
        /// <summary>
        /// Wheel Rotation 4
        /// </summary>
        Wheelrotation4,
        /// <summary>
        /// Wheel Rotation 5
        /// </summary>
        WheelRotation5,
        /// <summary>
        /// Wheel Rotation 6
        /// </summary>
        WheelRotation6,
        /// <summary>
        /// Wheel Rotation 7
        /// </summary>
        WheelRotation7,
        /// <summary>
        /// Wheel Rotation 8
        /// </summary>
        WheelRotation8,
        /// <summary>
        /// Strut Compression 1
        /// </summary>
        StrutCompression1,
        /// <summary>
        /// Strut Compression 2
        /// </summary>
        StrutCompression2,
        /// <summary>
        /// Strut Compression 3
        /// </summary>
        StrutCompression3,
        /// <summary>
        /// Strut Compression 4
        /// </summary>
        StrutCompression4,
        /// <summary>
        /// Strut Compression 5
        /// </summary>
        StrutCompression5,
        /// <summary>
        /// Strut Compression 6
        /// </summary>
        StrutCompression6,
        /// <summary>
        /// Strut Compression 7
        /// </summary>
        StrutCompression7,
        /// <summary>
        /// Strut Compression 8
        /// </summary>
        StrutCompression8
    }
    /// <summary>
    /// Enumeration of the DOF Ids in a simple Model
    /// </summary>
    [Guid("EEE67026-832C-457F-93B9-B39865DB96C3")]
    public enum SimpleDOFID
    {
        /// <summary>
        /// Left Vertical Stabilizer
        /// </summary>
        LeftStab,
        /// <summary>
        /// Right Vertical Stabilizer
        /// </summary>
        RightStab,
        /// <summary>
        /// Left Flaperon
        /// </summary>
        LeftFlaperon,
        /// <summary>
        /// right Flaperon
        /// </summary>
        RightFlaperon,
        /// <summary>
        /// Rudder
        /// </summary>
        Rudder,
        /// <summary>
        /// Nose Gear Rotation
        /// </summary>
        NoseGearRotate,
        /// <summary>
        /// Left Aileron
        /// </summary>
        LeftAileron,
        /// <summary>
        /// Right Aileron
        /// </summary>
        RightAileron,
        /// <summary>
        /// Ridder 1
        /// </summary>
        Rudder1,
        /// <summary>
        /// Rudder 2
        /// </summary>
        Rudder2,
        /// <summary>
        /// Airbrake
        /// </summary>
        Airbrake,
        /// <summary>
        /// Swing Wing 1
        /// </summary>
        SwingWing1,
        /// <summary>
        /// Swing Wing 2
        /// </summary>
        SwingWing2,
        /// <summary>
        /// Swing Wing 3
        /// </summary>
        SwingWing3,
        /// <summary>
        /// Swing Wing 4
        /// </summary>
        SwingWing4,
        /// <summary>
        /// Swing Wing 5
        /// </summary>
        SwingWing5,
        /// <summary>
        /// Swing Wing 6
        /// </summary>
        SwingWing6,
        /// <summary>
        /// Swing Wing 7
        /// </summary>
        SwingWing7,
        /// <summary>
        /// Swing Wing 8
        /// </summary>
        SwingWing8,
        /// <summary>
        /// Right Flap
        /// </summary>
        RightTEF,
        /// <summary>
        /// Left Flap
        /// </summary>
        LeftTEF,
        /// <summary>
        /// Right Leading Edge Flap
        /// </summary>
        RightLEF,
        /// <summary>
        /// Left Leading Edge Flap
        /// </summary>
        LeftLEF,
        /// <summary>
        /// Canopy
        /// </summary>
        Canopy,
        /// <summary>
        /// Propeller
        /// </summary>
        Propeller,
        /// <summary>
        /// Left Spoiler
        /// </summary>
        LeftSpoiler,
        /// <summary>
        /// Right Spoiler
        /// </summary>
        Rightspoiler,
        /// <summary>
        /// Wing Fold
        /// </summary>
        WingFold,
        /// <summary>
        /// Tail Hook
        /// </summary>
        TailHook,
        /// <summary>
        /// Bomb Doors
        /// </summary>
        BombDoors,
        /// <summary>
        /// Propeller RPM Control 1
        /// </summary>
        PropRPM1 = 40,
        /// <summary>
        /// Propeller RPM Control 2
        /// </summary>
        PropRPM2,
        /// <summary>
        /// Left Spoiler 1
        /// </summary>
        LeftSpoiler1,
        /// <summary>
        /// Right Spoiler 1
        /// </summary>
        RightSpoiler1,
        /// <summary>
        /// Left Spoiler 2
        /// </summary>
        LeftSpoiler2,
        /// <summary>
        /// Right spoiler 2
        /// </summary>
        RightSpoiler2,
    }
    /// <summary>
    /// Enumeration of the Switch IDs
    /// </summary>
    [Guid("47F7DC38-786D-44E8-9850-7CCCAAE7906E")]
    public enum SwitchID
    {
        /// <summary>
        /// Afterburner
        /// </summary>
        Afterburner,
        /// <summary>
        /// Nose Gear
        /// </summary>
        NoseGear,
        /// <summary>
        /// Left Main Gear
        /// </summary>
        LeftGear,
        /// <summary>
        /// Right Main Gear
        /// </summary>
        RightGear,
        /// <summary>
        /// nose Gear Rod
        /// </summary>
        NoseGearRod,
        /// <summary>
        /// Cockpit and Pilot
        /// </summary>
        CockpitandPilot,
        /// <summary>
        /// Wing Vapor
        /// </summary>
        WingVapor,
        /// <summary>
        /// Tail Strobe
        /// </summary>
        TailStrobe,
        /// <summary>
        /// winf Lights
        /// </summary>
        WingLights,
        /// <summary>
        /// Landing Lights
        /// </summary>
        LandingLights,
        /// <summary>
        /// Exhaust Nozzle
        /// </summary>
        EngineExhaustNozzle,
        /// <summary>
        /// FLIR Pod
        /// </summary>
        FLIRPod,
        /// <summary>
        /// HTS Pod
        /// </summary>
        HTSPod,
        /// <summary>
        /// Air Refueling Door
        /// </summary>
        ARDoor,
        /// <summary>
        /// Nose Gear Door
        /// </summary>
        NoseGearDoor,
        /// <summary>
        /// Left Main Gear Door
        /// </summary>
        LeftGearDoor,
        /// <summary>
        /// Right Main Gear Door
        /// </summary>
        RightGearDoor,
        /// <summary>
        /// Nose Gear Bay
        /// </summary>
        NoseGearBay,
        /// <summary>
        /// Left Main Gear Bay
        /// </summary>
        LeftGearBay,
        /// <summary>
        /// Right Main Gear Bay
        /// </summary>
        RightGearBay,
        /// <summary>
        /// Broken Nose Gear
        /// </summary>
        BrokenNoseGear,
        /// <summary>
        /// Broken Left Main Gear
        /// </summary>
        BrokenLeftGear,
        /// <summary>
        /// Broken Right Main Gear
        /// </summary>
        BrokenRightGear,
        /// <summary>
        /// Tail Hook
        /// </summary>
        Hook,
        /// <summary>
        /// Drag Chute
        /// </summary>
        DragChute
    }
    /// <summary>
    /// Enumeration of RenderControl Types
    /// </summary>
    [Guid("3F763FD1-C73B-49DE-AADB-09CC6657B66D")]
    public enum RenderControlType
    {
        /// <summary>
        ///  None
        /// </summary>
        None,
        /// <summary>
        /// Z-Bias Node
        /// </summary>
        Zbias,
        /// <summary>
        /// Complex DOF Math Calculation Node
        /// </summary>
        DOFMath
    }
    /// <summary>
    /// Enumerates the types of Math Operations a RenderControl can perform
    /// </summary>
    [Guid("8A7E7066-B187-4B33-BA43-F094E643C68F")]
    public enum RenderDOFMathType
    {
        /// <summary>
        /// Set 
        /// </summary>
        Set,
        /// <summary>
        /// Add
        /// </summary>
        Add,
        /// <summary>
        /// Subtract
        /// </summary>
        Subtract,
        /// <summary>
        /// Multiply
        /// </summary>
        Multiply,
        /// <summary>
        /// Divide
        /// </summary>
        Divide,
        /// <summary>
        /// Modulo
        /// </summary>
        Modulate,
        /// <summary>
        /// Cos
        /// </summary>
        Cos,
        /// <summary>
        /// ACos
        /// </summary>
        ACos,
        /// <summary>
        /// Sin
        /// </summary>
        Sin,
        /// <summary>
        /// ASin
        /// </summary>
        ASin,
        /// <summary>
        /// Tan
        /// </summary>
        Tan,
        /// <summary>
        /// ATan
        /// </summary>
        ATan,
        /// <summary>
        /// ATan2
        /// </summary>
        ATan2,
        /// <summary>
        /// Trig Function Angle From Adjecent and Hypotenuse
        /// </summary>
        AngleFromAdjHyp,
        /// <summary>
        /// Trig Function Angle From Opposite and Hypotenuse
        /// </summary>
        AngleFromOppHyp,
        /// <summary>
        /// Trig Function Angle From Opposite and Adjecent
        /// </summary>
        AngleFromOppAdj,
        /// <summary>
        /// Trig Function Side From Angle and Opposite
        /// </summary>
        LengthAdjFromAngleOpp,
        /// <summary>
        /// Trig Function Side From Angle and Adjecent
        /// </summary>
        LengthOppFromAngleAdj,
        /// <summary>
        /// Trig Function Angle from AngleSideAngle
        /// </summary>
        AngleAFromAngleSideSide,
        /// <summary>
        /// Trig Function Angle from SideAngleSide
        /// </summary>
        AngleAFromSideAngleSide,
        /// <summary>
        /// Trig Function Angle from SideSideSide
        /// </summary>
        AngleAFromSideSideSide,
        /// <summary>
        /// Trig Function Side from SideAngleSide
        /// </summary>
        SideAFromSideAngleSide,
        /// <summary>
        /// Clamp function
        /// </summary>
        Clamp,
        /// <summary>
        /// Normalize function
        /// </summary>
        Normalize,
        /// <summary>
        /// Adjusts frame speed calculations
        /// </summary>
        MultFrameTime
    }

    #endregion

    #region Interfaces
    /// <summary>
    /// Node Interface.  
    /// Provides a common interface for all the different types of BSP Nodes.
    /// </summary>
    [Guid("C8C230BE-31BE-46BB-9FD0-A004EC6880EE")]
    public interface IBSPNode
    {
        #region Properties
        /// <summary>
        /// The NodeType of this Node.
        /// </summary>
        NodeType NodeType
        { get; }
        /// <summary>
        /// The offset from the Root Node of the next Node to call after this Node is processed.  -1 returns to caller (No more nodes).
        /// </summary>
        long Sibling
        { get; set; }
        /// <summary>
        /// The offset of this Node relative to the Root Node.
        /// </summary>
        long NodeAddress
        { get; set; }
        /// <summary>
        /// Size of this BSP Node Data.
        /// </summary>
        int FileSize
        { get; }
        /// <summary>
        /// The Virtual File Table Entry.
        /// </summary>
        int VFT
        { get; set; }
        /// <summary>
        /// The Total Size of this Node on Disk including any SubTrees.
        /// </summary>
        int TotalSize
        { get; }
        /// <summary>
        /// Read-Only Count of the Number of <c>BSPNode</c> objects this Node represents including SubTrees.
        /// </summary>      
        int NodeCount
        { get; }
        #endregion

        #region Methods  
        /// <summary>
        /// Print the properties for this Node in a multi-line format
        /// </summary>
        /// <returns>
        /// Multi-Line <see cref="string"/> with a new line character at the end.
        /// </returns> 
        string Print();
        /// <summary>
        /// Debug Printing contains more data than the normal Print function.
        /// </summary>
        /// <returns>Multi-Line <see cref="string"/> with a new line at the end.</returns> 
        string DebugPrint();
        /// <summary>
        /// Writes the <c>BSPNode</c> Data to the <see cref="Stream"/>.
        /// </summary>
        /// <returns><see cref="bool"/> <c>true</c> if successful or <c>false</c> if unsuccessful.</returns>
        /// <param name="stream"><see cref="Stream"/> Must be open and at the correct position prior to calling this function.</param>
        bool Save(Stream stream);
        /// <summary>
        /// Returns a list of the Node Types for this Node and any SubTree Nodes.
        /// </summary>
        /// <returns></returns>
        List<int> GetNodeTypes();
        /// <summary>
        /// Updates the Root Pointer for the Node to reference.
        /// </summary>
        /// <param name="root"></param>
        void UpdateRoot(long root);
        #endregion       
    }
    #endregion

    #region Classes
    /// <summary>
    /// Container Base Class for all the Nodes to inherit from. 
    /// </summary>
    public abstract class BSPNode
    {
        #region Properties
        /// <summary>
        /// The <see cref="NodeType"/> of this Node.
        /// </summary>
        public NodeType NodeType
        { get { return _NodeType; } }           // Type of Node we are dealing with
        /// <summary>
        /// Size of this BSP Node Data.
        /// </summary>
        public int FileSize
        { get { return _Size; } }
        /// <summary>
        /// The Total Size of this <c>BSPNode</c> including SubTrees.
        /// </summary>
        public int TotalSize
        {
            get { return _Size; }            
        }
        /// <summary>
        /// The offset of this Node relative to the Root Node.
        /// </summary>        
        public long NodeAddress
        {
            get { return _NodePtr; }
            set { _NodePtr = value; }
        }
        /// <summary>
        /// Read-Only Count of the Number of <c>BSPNode</c> objects this Node represents including SubTrees.
        /// </summary>  
        public int NodeCount
        {
            get { return 1; }
        }
        #endregion

        #region Fields
        /// <summary>
        /// The start point in the File of this LOD tree.
        /// </summary>
        protected long _RootPtr;              // Start point of the Node
        /// <summary>
        /// The point in the File where this Node was read from.
        /// </summary>
        protected long _NodePtr;              // File Position of this node
        /// <summary>
        /// Internal Line Counter to help with Debug Printing.
        /// </summary>
        protected long _lineCount;            // Line Counters to help with Debug Outout
        /// <summary>
        /// Enumerated NodeType.  Exposed to the IBSPNode Interface to identify the Type of Node this is.
        /// </summary>
        protected NodeType _NodeType;         // Modifiable NodeType  
        /// <summary>
        /// The Size of this Node Data on Disk.
        /// </summary>
        protected int _Size = 0;
        
        #endregion

        #region Constructors
        //Abstract classes do not have constructors
        //protected BSPNode() { }
        #endregion

        #region Methods
        /// <summary>
        /// Helper Function to Load a Primitive from a file.
        /// </summary>
        /// <param name="stream"><see cref="Stream"/>;  Must be open and at the correct stream position prior to calling this function.</param>
        /// <returns>IPrimitive as Primitive or Polygon Object</returns>
        protected IPrimitive LoadPrim(Stream stream)
        {
            try
            {
                using (BinaryReader reader = new BinaryReader(stream, System.Text.Encoding.Default, true))
                {
                    // Get the Prim/Poly Type
                    int PrimType = reader.ReadInt32();

                    // Create the Prim/Poly based on the type
                    switch (PrimType)
                    {
                        case 0:
                            return new PrimitivePoint(reader.BaseStream, _RootPtr);

                        case 1:
                            return new PrimitiveLine(reader.BaseStream, _RootPtr);

                        case 2:
                        case 14:
                            return new PolyFC(reader.BaseStream, _RootPtr, (PolyType)PrimType);

                        case 3:
                        case 15:
                            return new PolyFCN(reader.BaseStream, _RootPtr, (PolyType)PrimType);

                        case 4:
                        case 16:
                            return new PolyVC(reader.BaseStream, _RootPtr, (PolyType)PrimType);

                        case 5:
                        case 17:
                            return new PolyVCN(reader.BaseStream, _RootPtr, (PolyType)PrimType);

                        case 6:
                        case 10:
                        case 18:
                        case 22:
                        case 26:
                            return new PolyTexFC(reader.BaseStream, _RootPtr, (PolyType)PrimType);

                        case 7:
                        case 11:
                        case 19:
                        case 23:
                            return new PolyTexFCN(reader.BaseStream, _RootPtr, (PolyType)PrimType);

                        case 8:
                        case 12:
                        case 20:
                        case 24:
                            return new PolyTexVC(reader.BaseStream, _RootPtr, (PolyType)PrimType);

                        case 9:
                        case 13:
                        case 21:
                        case 25:
                            return new PolyTexVCN(reader.BaseStream, _RootPtr, (PolyType)PrimType);

                        default:
                            break;
                    }
                }
            }
            catch (Exception ex)
            {

                throw new Exception("There was an error while reading a Primitive Object. \r\n" + ex.Message, ex);
            }
             
            // This should never be called, but it's good to include it
            return null;
        }

        /// <summary>
        /// Generic Template Function for saving Node Data.
        /// </summary>
        /// <returns></returns>
        protected bool Save(Stream stream)
        {
            return true;
        }        
        #endregion
    }

    /// <summary>
    /// The generic Base Node which contains the VFT and Sibling pointer.
    /// Inherited in Every Node: 
    /// Indirect inheritance in <see cref="BRootNode"/> and <see cref="BDOFNode"/> through <see cref="BSubTreeNode"/>.
    /// Indirect inheritance in <see cref="BLightStringNode"/> through <see cref="BPrimitiveNode"/>.
    /// </summary>
    [Guid("773CDDB8-9B3F-4557-8FCD-17C056814333")]
    public class BNode : BSPNode, IBSPNode
    {
        #region Properties
        /// <summary>
        /// The Virtual File Table Entry.
        /// </summary>
        public int VFT
        {
            get { return _VFT; }
            set { _VFT = value; }
        }
        /// <summary>
        /// The offset from the Root Node of the next Node to call after this Node is processed.  -1 returns to caller (No more nodes).
        /// </summary>
        public long Sibling
        {
            get { return _Sibling; }
            set { _Sibling = value; }
        }        
        #endregion

        #region Fields
        /// <summary>
        /// The Sibling Pointer to the next Node in the Tree.  -1 for the Last Node in a Tree.
        /// </summary>
        protected long _Sibling;
        /// <summary>
        /// The VFT indicator for the Node.  Contains NodeTypes for Nested Nodes.
        /// </summary>
        protected int _VFT;
        /// <summary>
        /// The previous node pointer used for writing the nodes to file.  Shared Sibling Variable.
        /// </summary>
        protected static long _lastNode;
        #endregion

        #region Constructors
        /// <summary>
        /// Returns an uninitialized object of type BNode.
        /// </summary>
        public BNode()
        {
            _NodePtr = 0;
            _NodeType = NodeType.BNode;
            _VFT = 0;
            _Sibling = 0;
            _Size += 8;
        }

        /// <summary>
        /// Returns an object of Type <see cref="BNode"/>.
        /// </summary> 
        /// <param name="vft"><see cref="int"/> The VFT Entry for this Node in <see cref="Int32"/> Format</param>
        /// <param name="sibling">Sibling pointers are passed as relative offsets from the Root Node.</param>
        public BNode(int vft, int sibling)
        {
            _NodePtr = 0;
            _NodeType = NodeType.BNode;
            _VFT = vft;
            _Sibling = sibling;
            _Size += 8;
        }

        /// <summary>
        /// Returns an initialized object of type BNode.
        /// </summary>
        /// <remarks>This Constructor should be used when reading from a LOD File.</remarks>
        /// <param name="stream"><see cref="Stream"/>;  Must be open and at the correct stream position prior to calling this function.</param>
        /// <param name="root">The file offset of the Root Node.</param>
        public BNode(Stream stream, long root)
        {
            _RootPtr = root;
            try
            {
                using (BinaryReader reader = new BinaryReader(stream, System.Text.Encoding.Default, true))
                {
                    _lineCount = reader.BaseStream.Position -4;
                    _NodePtr = _lineCount - _RootPtr;
                    FillNode(reader);
                }
            }
            catch (Exception ex)
            {

                throw new Exception("There was an error while reading the BNode Data at " + _NodePtr + "\r\n" + ex.Message, ex);
            }
            _Size += 8;            
        }
        #endregion

        #region Methods
        /// <summary>
        /// Print the properties for this Node in a multi-line format
        /// </summary>
        /// <returns>
        /// Multi-Line <see cref="string"/> with a new line character at the end.
        /// </returns> 
        public string Print()
        {
            string retText = "******** " + _NodeType + " ********\r\n";
            retText += "VFT: " + VFT + "\r\nSibling Pointer: " + Sibling;
            return retText + "\r\n";
        }

        /// <summary>
        /// Debug Printing contains more data than the normal Print function.
        /// </summary>
        /// <returns>Multi-Line <see cref="string"/> with a new line at the end.</returns> 
        public string DebugPrint()
        {
            _lineCount = _RootPtr + _NodePtr;
            string retText = "************* " + _NodeType + " *************\r\n";
            retText += "******** BNode Data ********\r\n" +
                "Size: " + _Size + "\r\n";
            retText += "Node Address: " + _NodePtr + "\r\n";
            retText += "Node Count: " + NodeCount + "\r\n";
            retText+= "(" + _lineCount + ") VFT: " + VFT + "\r\n"+
                "(" + (_lineCount + 4) + ") Sibling Pointer: " + Sibling;            
            if (_Sibling != -1)
                retText += " (" + (_RootPtr + Sibling) + ")";
            retText += "\r\n";
            _lineCount += 8;
                     
            return retText;
        }

        /// <summary>
        /// Writes the <c>BSPNode</c> Data to the <see cref="Stream"/>.
        /// </summary>
        /// <returns><see cref="bool"/> <c>true</c> if successful or <c>false</c> if unsuccessful.</returns>
        /// <param name="stream"><see cref="Stream"/> Must be open and at the correct position prior to calling this function.</param>
        public new bool Save(Stream stream)
        {
            BinaryWriter writer = new BinaryWriter(stream);
            try
            {
                writer.Write(_VFT);
                writer.Write((int)_lastNode);
            }
            catch (Exception ex)
            {
                throw new Exception("There was an error while writing the BNode Data for the Node at " + _NodePtr, ex);
            }
            return true;
        }

        /// <summary>
        /// Returns a list of the Node Types for this Node and any SubTree Nodes.
        /// </summary>
        /// <returns></returns>
        public List<int> GetNodeTypes()
        {                   
            return new List<int>
            {
                (int)_NodeType
            };
        }

        /// <summary>
        /// Updates the Root Pointer for the Node to reference.
        /// </summary>
        /// <param name="root"></param>
        public void UpdateRoot(long root)
        {
            _RootPtr = root;
        }

        /// <summary>
        /// Helper function to read the Node data from the provided stream.
        /// </summary>        
        /// <param name="reader"><see cref="BinaryReader"/>;  Must be open and at the correct stream position prior to calling this function.</param>
        protected int FillNode(BinaryReader reader)
        {            
            _Sibling = reader.ReadInt32();
            if (_Sibling < -1 || _Sibling > reader.BaseStream.Length)
                throw new Exception("Invalid Sibling Pointer");
            return 1;
        }
        #endregion
    }

    /// <summary>
    /// SubTree Node.
    /// Inherits <see cref="BNode"/>. 
    /// Inherited By <see cref="BRootNode"/>.  
    /// Inherited by <see cref="BDOFNode"/>. 
    /// </summary>
    [Guid("B48C50F7-34D3-44D2-9CD7-055A30AD7601")]
    public class BSubTreeNode : BNode, IBSPNode
    {
        #region Properties
        /// <summary>
        /// Collection of System.Windows.Media.Media3D.Point3D Objects to represent the 3D Coordinates where this SubTree exists. 
        /// </summary>
        public List<System.Windows.Media.Media3D.Point3D> Coordinates
        {
            get { return _Coords; }
            set {
                _Coords = value;
                _nCoords = _Coords.Count;                
            }
        }
        /// <summary>
        /// Collection of System.Windows.Media.Media3D.Point3D Objects to represent the 3D Dynamic Coordinates for this SubTree.
        /// </summary>
        public List<System.Windows.Media.Media3D.Point3D> DynamicCoordinates
        {
            get { return _DynCoords; }
            set {
                _DynCoords = value;
                _nDynamics = _DynCoords.Count;                
            }
        }
        /// <summary>
        /// Collection of F4BMS.Normal Objects to represent the normals for this SubTree Node.
        /// </summary>
        public List<Normal> Normals
        {
            get { return _Normals; }
            set {
                _Normals = value;
                _nNormals = _Normals.Count;                
            }
        }
        /// <summary>
        /// The File Offset relative to the Root Node where the SubTree exists.  The Node at this location will be processed after the current node.
        /// </summary>
        public long SubTreePointer
        {
            get { return _SubTreePtr; }            
        }
        /// <summary>
        /// Collection of the Nodes which make up this SubTree.
        /// </summary>
        public List<IBSPNode> SubTree
        {
            get { return _SubTree; }
            set {
                _SubTree = value;                
            }
        }
        /// <summary>
        /// The Total Size on Disk of the SubTree, including all Child Nodes and Trees.
        /// </summary>
        public new int TotalSize
        {
            get
            {
                if (_SubTree == null || _SubTree.Count == 0)
                    return _Size + (12 * (_nCoords + _nDynamics + _nNormals));
                int _TreeSize = 0;
                foreach (IBSPNode node in _SubTree)
                    _TreeSize += node.TotalSize;
                return _Size + _TreeSize + (12 * (_nCoords + _nDynamics + _nNormals));
            }            
        }
        /// <summary>
        /// Read-Only Count of the Number of <c>BSPNode</c> objects this Node represents including SubTrees.
        /// </summary>
        public new int NodeCount
        {
            get
            {
                int count = 1;
                foreach (IBSPNode node in _SubTree)
                    count += node.NodeCount;
                return count;
            }
        }
        /// <summary>
        /// The offset of this Node relative to the Root Node.
        /// </summary>
        public new long NodeAddress
        {
            get { return _NodePtr; }
            set
            {
                _NodePtr = value;               
            }
        }
        #endregion

        #region Fields
        /// <summary>
        /// List of Coords for this Node
        /// </summary>
        protected List<System.Windows.Media.Media3D.Point3D> _Coords;
        /// <summary>
        /// File Position for the Coords
        /// </summary>
        protected long _CoordsPtr;
        /// <summary>
        /// Number of Coords
        /// </summary>
        protected int _nCoords;
        /// <summary>
        /// List of DynCoords for this Node
        /// </summary>
        protected List<System.Windows.Media.Media3D.Point3D> _DynCoords;
        /// <summary>
        /// Number of Dynamics 
        /// </summary>
        protected int _nDynamics;
        /// <summary>
        /// File Position of Dynamic Coords  
        /// </summary>
        protected long _DynamicsPtr;
        /// <summary>
        /// List of Normals for this Node
        /// </summary>
        protected List<Normal> _Normals;
        /// <summary>
        /// File position of the Normals
        /// </summary>
        protected long _NormalsPtr;
        /// <summary>
        /// Number of Normals
        /// </summary>
        protected int _nNormals;
        /// <summary>
        /// The pointer to the SubTree  
        /// </summary>
        protected long _SubTreePtr;
        /// <summary>
        /// The Nodes in this SubTree
        /// </summary>
        protected List<IBSPNode> _SubTree;
        
        #endregion

        #region Constructors
        /// <summary>
        /// Returns an uninitialized object of type <see cref="BSubTreeNode"/>.
        /// </summary>
        public BSubTreeNode() : base()
        {
            _NodeType = NodeType.SubTreeNode;
            _VFT = (int)_NodeType;

            // Initialize the Local Fields
            _Coords = new List<System.Windows.Media.Media3D.Point3D>();
            _CoordsPtr = 0;
            _nCoords = 0;
            _DynCoords = new List<System.Windows.Media.Media3D.Point3D>();
            _DynamicsPtr = 0;
            _nDynamics = 0;
            _Normals = new List<Normal>();
            _NormalsPtr = 0;
            _nNormals = 0;
            _SubTreePtr = 0;
            _SubTree = new List<IBSPNode>();
            _Size += 28;
        }

        /// <summary>
        /// Returns an initialized object of type <see cref="BSubTreeNode"/>.
        /// </summary>
        /// <remarks>This Constructor should be used when reading from a LOD File.</remarks>
        /// <param name="stream"><see cref="Stream"/>;  Must be open and at the correct stream position prior to calling this function.</param>
        /// <param name="root">The File Offset of the Root Node.</param>
        public BSubTreeNode(Stream stream, long root) : base(stream, root)
        {
            _NodeType = NodeType.SubTreeNode;
            _VFT = (int)_NodeType;
            _SubTree = new List<IBSPNode>();
            _DynCoords = new List<System.Windows.Media.Media3D.Point3D>();
            _Coords = new List<System.Windows.Media.Media3D.Point3D>();
            _Normals = new List<Normal>();
            try
            {
                using (BinaryReader reader = new BinaryReader(stream, System.Text.Encoding.Default, true))
                {
                    // Fill the SubTree specific Data
                    FillNode(reader);
                }
            }            
            catch (Exception ex)
            {
                throw new Exception("There was an error reading the SubTree Node at " + _NodePtr + "\r\n" + ex.Message, ex);
            }
            // SubTree Nodes are filled via the Calling LOD Structure
        }
        #endregion

        #region Methods
        /// <summary>
        /// Print the properties for this Node in a multi-line format
        /// </summary>
        /// <returns>
        /// Multi-Line <see cref="string"/> with a new line character at the end.
        /// </returns> 
        public new string Print()
        {
            string retText = base.Print();
            retText += "Number of Coordinates: " + _nCoords + "\r\n";
            for (int i = 0; i < _nCoords; i++)
                retText += "    (" + _Coords[i].X + ", " + _Coords[i].Y + ", " + _Coords[i].Z + ")\r\n";
            retText += "Number of Dynamic Coordinates: " + _nDynamics + "\r\n";
            for (int i = 0; i < _nDynamics; i++)
                retText += "    (" + _DynCoords[i].X + ", " + _DynCoords[i].Y + ", " + _DynCoords[i].Z + ")\r\n";
            retText += "Number of Normals: " + _nNormals + "\r\n";
            for (int i = 0; i < _nNormals; i++)
                retText += "    (" + _Normals[i].I + ", " + _Normals[i].J + ", " + _Normals[i].K + ")\r\n";
            retText += "SubTree: " + _SubTreePtr + "\r\n";
            foreach (IBSPNode node in _SubTree)
                retText += node.Print();
            return retText;
        }

        /// <summary>
        /// Debug Printing contains more data than the normal Print function.
        /// </summary>
        /// <returns>Multi-Line <see cref="string"/> with a new line at the end.</returns> 
        public new string DebugPrint()
        {

            string retText = base.DebugPrint();
            retText += "******** SubTree Data ********\r\n";
            retText += "(" + _lineCount + ") Coordinates Pointer: " + _CoordsPtr;
            if (_CoordsPtr != -1)
                retText += " (" + (_CoordsPtr + _RootPtr) + ")";
            retText+= "\r\n"; _lineCount += 4;
            retText += "(" + _lineCount + ") Number of Coordinates: " + _nCoords + "\r\n"; _lineCount += 4;
            retText += "(" + _lineCount + ") Number of Dynamic Coordinates: " + _nDynamics + "\r\n"; _lineCount += 4;
            retText += "(" + _lineCount + ") Dynamic Coordinates Pointer: " + _DynamicsPtr;
            if (_DynamicsPtr != -1)
                retText += " (" + (_DynamicsPtr + _RootPtr) + ")";
            retText+="\r\n"; _lineCount += 4;
            retText += "(" + _lineCount + ") Normals Pointer: " + _NormalsPtr;
            if (_NormalsPtr != -1)
                retText += " (" + (_NormalsPtr + _RootPtr) + ")";
            retText+="\r\n"; _lineCount += 4;
            retText += "(" + _lineCount + ") Number of Normals: " + _nNormals + "\r\n"; _lineCount += 4;
            retText += "(" + _lineCount + ") SubTree Pointer: " + _SubTreePtr;
            if (_SubTreePtr != -1)
                retText += " (" + (_SubTreePtr + _RootPtr) + ")";
            retText+="\r\n"; _lineCount += 4;
            retText += "Child Count: " + _SubTree.Count + "\r\n";
            foreach (IBSPNode node in _SubTree)
                retText += node.DebugPrint();


            retText += "\r\nCoordinates: \r\n";
            for (int i = 0; i < _nCoords; i++)
                retText += "(" + (_RootPtr + _CoordsPtr + (12 * i)) + ")     (" + _Coords[i].X + ", " + _Coords[i].Y + ", " + _Coords[i].Z + ")\r\n";
            retText += "\r\nDynamic Coordinates: \r\n";
            for (int i = 0; i < _nDynamics; i++)
                retText += "(" + (_RootPtr + _DynamicsPtr + (12 * i)) + ")     (" + _DynCoords[i].X + ", " + _DynCoords[i].Y + ", " + _DynCoords[i].Z + ")\r\n";
            retText += "\r\nNormals: \r\n";
            for (int i = 0; i < _nNormals; i++)
                retText += "(" + (_RootPtr + _NormalsPtr + (12 * i)) + ")     (" + _Normals[i].I + ", " + _Normals[i].J + ", " + _Normals[i].K + ")\r\n";
            return retText;
        }

        /// <summary>
        /// Writes the <c>BSPNode</c> Data to the <see cref="Stream"/>.
        /// </summary>
        /// <returns><see cref="bool"/> <c>true</c> if successful or <c>false</c> if unsuccessful.</returns>
        /// <param name="stream"><see cref="Stream"/> Must be open and at the correct position prior to calling this function.</param>
        public new bool Save(Stream stream)
        {
            _NodePtr = stream.Position - _RootPtr;
            // Pointers are all stored in the file as relative offsets from the ROOT NODE
            // They must be updated prior to writing to account for any changes in the numvber of coordinates, dynamics, textures, etc...
            UpdatePointers();
            // Write the VFT and Sibling data
            base.Save(stream);
            // Write the SubTree Node Data
            
            try
            {
                using (BinaryWriter writer = new BinaryWriter(stream, System.Text.Encoding.Default, true))
                {
                    // Write the generic node data to the stream
                    writer.Write((int)_CoordsPtr);
                    writer.Write(_nCoords);
                    writer.Write(_nDynamics);
                    writer.Write((int)_DynamicsPtr);
                    writer.Write((int)_NormalsPtr);
                    writer.Write(_nNormals);
                    writer.Write((int)_SubTreePtr);

                    // This Class is inherited so we may need extra data depending on the actual Node Type
                    if (_NodeType == NodeType.RootNode)
                    {
                        writer.Write((int)(this as BRootNode).TexturePointer);
                        writer.Write((this as BRootNode).TextureCount);
                        writer.Write((this as BRootNode).ScriptID);
                    }

                    if (_NodeType == NodeType.DOFNode)
                    {
                        writer.Write((int)(this as BDOFNode).DOFID);
                        for (int i = 0; i < 3; i++)
                            for (int j = 0; j < 3; j++)
                                writer.Write((Single)(this as BDOFNode).RotationMatrix[i, j]);
                        writer.Write((Single)(this as BDOFNode).RotationPoint.X);
                        writer.Write((Single)(this as BDOFNode).RotationPoint.Y);
                        writer.Write((Single)(this as BDOFNode).RotationPoint.Z);
                    }

                    if (_NodeType == NodeType.TransNode)
                    {
                        writer.Write((int)(this as BTransNode).DOFID);
                        writer.Write((Single)(this as BTransNode).Min);
                        writer.Write((Single)(this as BTransNode).Max);
                        writer.Write((Single)(this as BTransNode).Multiplier);
                        writer.Write((Single)(this as BTransNode).Future);
                        writer.Write((this as BTransNode).Flags);
                        writer.Write((Single)(this as BTransNode).TranslationPoint.X);
                        writer.Write((Single)(this as BTransNode).TranslationPoint.Y);
                        writer.Write((Single)(this as BTransNode).TranslationPoint.Z);
                    }

                    if (_NodeType == NodeType.ScaleNode)
                    {
                        writer.Write((int)(this as BScaleNode).DOFID);
                        writer.Write((Single)(this as BScaleNode).Min);
                        writer.Write((Single)(this as BScaleNode).Max);
                        writer.Write((Single)(this as BScaleNode).Multiplier);
                        writer.Write((Single)(this as BScaleNode).Future);
                        writer.Write((this as BScaleNode).Flags);
                        writer.Write((Single)(this as BScaleNode).ScalePoint.X);
                        writer.Write((Single)(this as BScaleNode).ScalePoint.Y);
                        writer.Write((Single)(this as BScaleNode).ScalePoint.Z);
                        writer.Write((Single)(this as BScaleNode).TranslationPoint.X);
                        writer.Write((Single)(this as BScaleNode).TranslationPoint.Y);
                        writer.Write((Single)(this as BScaleNode).TranslationPoint.Z);
                    }

                    if (_NodeType == NodeType.XDOFNode)
                    {
                        writer.Write((int)(this as BXDofNode).DOFID);
                        writer.Write((Single)(this as BXDofNode).Min);
                        writer.Write((Single)(this as BXDofNode).Max);
                        writer.Write((Single)(this as BXDofNode).Multiplier);
                        writer.Write((Single)(this as BXDofNode).Future);
                        writer.Write((this as BXDofNode).Flags);
                        for (int i = 0; i < 3; i++)
                            for (int j = 0; j < 3; j++)
                                writer.Write((Single)(this as BXDofNode).RotationMatrix[i, j]);
                        writer.Write((Single)(this as BXDofNode).TranslationPoint.X);
                        writer.Write((Single)(this as BXDofNode).TranslationPoint.Y);
                        writer.Write((Single)(this as BXDofNode).TranslationPoint.Z);
                    }

                    // Recursive call to write the data for the subtree nodes
                    _lastNode = -1;
                    for (int i = _SubTree.Count-1; i>=0;i--)
                        _SubTree[i].Save(stream);

                    // Write the extra data for the subtree if it exists
                    foreach (System.Windows.Media.Media3D.Point3D p in _Coords)
                    {
                        writer.Write((Single)p.X);
                        writer.Write((Single)p.Y);
                        writer.Write((Single)p.Z);
                    }
                    foreach (System.Windows.Media.Media3D.Point3D p in _DynCoords)
                    {
                        writer.Write((Single)p.X);
                        writer.Write((Single)p.Y);
                        writer.Write((Single)p.Z);
                    }
                    foreach (Normal p in _Normals)
                    {
                        writer.Write((Single)p.I);
                        writer.Write((Single)p.J);
                        writer.Write((Single)p.K);
                    }
                }
            }
            catch (Exception ex)
            {
                switch (_NodeType)
                {
                    case NodeType.RootNode:
                        throw new Exception("There was an error while writing the Root Node\r\n" + ex.Message, ex);

                    case NodeType.SubTreeNode:
                        throw new Exception("There was an error while writing the SubTree Node at " + _NodePtr + "\r\n" + ex.Message, ex);

                    case NodeType.ScaleNode:
                        throw new Exception("There was an error while writing the Scale Node at " + _NodePtr + "\r\n" + ex.Message, ex);

                    case NodeType.XDOFNode:
                        throw new Exception("There was an error while writing the XDOF Node at " + _NodePtr + "\r\n" + ex.Message, ex);

                    case NodeType.TransNode:
                        throw new Exception("There was an error while writing the Trans Node at " + _NodePtr + "\r\n" + ex.Message, ex);

                    case NodeType.DOFNode:
                        throw new Exception("There was an error while writing the DOF Node at " + _NodePtr + "\r\n" + ex.Message, ex);


                }                
            }
            _lastNode = _NodePtr;
            return true;
        }

        /// <summary>
        /// Returns a list of the Node Types for this Node and any SubTree Nodes.
        /// </summary>
        /// <returns></returns>
        public new List<int> GetNodeTypes()
        {
            List<int> nodetypes = new List<int>
            {
                (int)_NodeType
            };
            foreach (IBSPNode node in _SubTree)
                nodetypes.AddRange(node.GetNodeTypes());
            return nodetypes;
        }

        /// <summary>
        /// Updates the Root Pointer for the Node to reference.
        /// </summary>
        /// <param name="root"></param>
        public new void UpdateRoot(long root)
        {
            _RootPtr = root;
            foreach (IBSPNode node in _SubTree)
                node.UpdateRoot(root);            
        }

        /// <summary>
        /// Updates Sizes and Pointers for the Node and SubTree Nodes 
        /// </summary>
        protected void UpdatePointers()
        {
            //Get the size of the Tree
            int _TreeSize = 0;
            foreach (IBSPNode node in _SubTree)
                _TreeSize += node.TotalSize;
            // Pointers need to be set to an offset from the RootNode via NodePtr          
            _CoordsPtr = _NodePtr + _Size + _TreeSize;
            // The remaining Ptrs can be offset from Coords
            if (_nDynamics > 0)
                _DynamicsPtr = _CoordsPtr + (12 * _nCoords);
            else
                _DynamicsPtr = -1;
            if (_nNormals > 0)
                _NormalsPtr = _CoordsPtr + (12 * (_nCoords + _nDynamics));
            else
                _NormalsPtr = -1;
            // Nodes are written to file in reverse order so we need the pointer to the last node of this tree as it appears in the file
            if (_SubTree.Count > 0)
                _SubTreePtr = _NodePtr + _Size + (_TreeSize - (SubTree[0].TotalSize));
            else
                _SubTreePtr = -1;

            // Inherited Class pointers
            if (_NodeType == NodeType.RootNode)
                (this as BRootNode).TexturePointer = _CoordsPtr + (12 * (_nCoords + _nDynamics + _nNormals));
            
        }

        /// <summary>
        /// Helper function to read the data for this node
        /// </summary>
        /// <remarks>reader must already be open and at the correct Position in the stream</remarks>
        /// <param name="reader">BinaryReader</param>
        private new int FillNode(BinaryReader reader)
        {
            // Add the SubTree data
            _CoordsPtr = reader.ReadInt32();
            _nCoords = reader.ReadInt32();
            _nDynamics = reader.ReadInt32();
            _DynamicsPtr = reader.ReadInt32();
            _NormalsPtr = reader.ReadInt32();
            _nNormals = reader.ReadInt32();
            _SubTreePtr = reader.ReadInt32();

            // Fill the Lists   
            if (_nCoords > 0 && _CoordsPtr != 1)
                _Coords = FillCoords(reader, _nCoords, reader.BaseStream.Position, _CoordsPtr + _RootPtr);
            if (_nDynamics > 0)
                _DynCoords = FillCoords(reader, _nDynamics, reader.BaseStream.Position, _DynamicsPtr + _RootPtr);
            if (_nNormals > 0)
                _Normals = FillNormals(reader, _nNormals, reader.BaseStream.Position, _NormalsPtr + _RootPtr);
            
            _Size += 28;
            if ((_CoordsPtr < -1 && _nCoords != 0) || (_DynamicsPtr < -1 && _nDynamics != 0) || (_NormalsPtr < -1 && _nNormals!=0))
                throw new Exception("Invalid Pointer Assignment");
            return 1;
        }

        /// <summary>
        /// Helper function to read the Coordinates and Dynamic Coordinates for this node
        /// </summary>        
        /// <param name="reader">BinaryReader</param>
        /// /// <remarks>reader must already be open and at the correct Position in the stream</remarks>
        /// <param name="count">Nmber of Coordinates to read</param>
        /// <param name="returnAddress">The position of the File Stream to return to after the read is complete</param>
        /// <param name="dataAddress">The position in the file where the data is located</param>
        /// <returns>List of Point3Ds to represent either the Coordinates or the Dynamic Coordinates (x,y,z)</returns>
        private List<System.Windows.Media.Media3D.Point3D> FillCoords(BinaryReader reader, int count, long returnAddress, long dataAddress)
        {
            // Initialize a new list
            List<System.Windows.Media.Media3D.Point3D> PointList = new List<System.Windows.Media.Media3D.Point3D>();

            // Seek to the File position for the data
            reader.BaseStream.Position = dataAddress;

            // Fill the list
            for (int i = 0; i < count; i++)
            {
                PointList.Add(new System.Windows.Media.Media3D.Point3D(reader.ReadSingle(), reader.ReadSingle(), reader.ReadSingle()));
            }

            reader.BaseStream.Position = returnAddress;
            return PointList;
        }

        /// <summary>
        /// Helper function to read the Normal data for this node
        /// </summary>
        /// <param name="reader">BinaryReader</param>
        /// <remarks>reader must already be open and at the correct Position in the stream</remarks>
        /// <param name="count">Number of Normals to read</param>
        /// <param name="returnAddress">The position of the File Stream to return to after the read is complete</param>
        /// <param name="dataAddress">The position in the file where the data is located</param>
        /// <returns>List of Normal Data (I,J,K) as a Normal Class Object</returns>
        private List<Normal> FillNormals(BinaryReader reader, int count, long returnAddress, long dataAddress)
        {
            // Initialize a new list
            List<Normal> PointList = new List<Normal>();

            // Seek to the File position for the data
            reader.BaseStream.Position = dataAddress;

            // Fill the list
            for (int i = 0; i < count; i++)
            {
                PointList.Add(new Normal(reader.ReadSingle(), reader.ReadSingle(), reader.ReadSingle()));
            }

            reader.BaseStream.Position = returnAddress;
            return PointList;
        }
        #endregion
    }

    /// <summary>
    /// Root node found at the beginning of each LOD.
    /// Inherits <see cref="BSubTreeNode"/>.
    /// </summary>
    [Guid("B1E28A51-1A4B-4EB6-B41E-C19D4048F5CF")]
    public class BRootNode : BSubTreeNode, IBSPNode
    {
        #region Properties
        /// <summary>
        /// Script ID used internally by the Renderer.
        /// </summary>
        public int ScriptID
        {
            get { return _ScriptID; }
            set { _ScriptID = value; }
        }
        /// <summary>
        /// Read-Only Count of Textures.
        /// </summary>
        public int TextureCount
        { get { return _nTextures; } }
        /// <summary>
        /// Array of Int32 objects that hold the Indices of the Textures.
        /// </summary>
        public List<int> Textures
        {
            get { return _Textures; }
            set
            {
                _Textures = value;
                _nTextures = _Textures.Count;
            }
        }
        /// <summary>
        /// The Total Size of the Tree including all SubTrees.
        /// </summary>
        public new int TotalSize
        {
            get
            {
                return base.TotalSize + (4 * _nTextures);
            }
        }
        /// <summary>
        /// Read-Only Count of the Number of <c>BSPNode</c> objects this Node represents including SubTrees.
        /// </summary>
        public new int NodeCount
        {
            get
            {
                return base.NodeCount;
            }
        }
        /// <summary>
        /// The Offset from the Root Node where the Textures are stored.
        /// </summary>
        public long TexturePointer
        {
            get { return _TexturePtr; }
            set { _TexturePtr = value; }
        }
        /// <summary>
        /// The offset of this Node relative to the Root Node.
        /// </summary>
        public new long NodeAddress
        {
            get { return _NodePtr; }
            set
            {
                _NodePtr = value;                
            }
        }
        #endregion

        #region Fields
        private long _TexturePtr;
        private int _nTextures;
        private int _ScriptID;
        private List<int> _Textures;
        #endregion

        #region Constructors
        /// <summary>
        /// Returns an uninitialized object of type <see cref="BRootNode"/>.
        /// </summary>
        public BRootNode() : base()
        {
            _NodeType = NodeType.RootNode;
            _VFT = (int)_NodeType;

            // Initialize the Local Data
            _TexturePtr = 0;
            _nTextures = 0;
            _ScriptID = 0;
            _Textures = new List<int>();
            _Size += 12;
        }

        /// <summary>
        /// Returns an object of type <see cref="BRootNode"/>.
        /// </summary>
        /// <remarks>This Constructor should be used when reading from a LOD File.</remarks>
        /// <param name="stream"><see cref="Stream"/>;  Must be open and at the correct stream position prior to calling this function.</param>
        /// <param name="root">The file offset of the Root Node.</param>
        public BRootNode(Stream stream, long root) : base(stream, root)
        {
            _NodeType = NodeType.RootNode;
            _VFT = (int)_NodeType;
            try
            {
                using (BinaryReader reader = new BinaryReader(stream, System.Text.Encoding.Default, true))
                {
                    FillNode(reader);
                }
            }
            catch (Exception ex)
            {

                throw new Exception("There was an error reading the Root Node Data\r\n" + ex.Message, ex);
            }
               
            
        }
        #endregion

        #region Methods
        /// <summary>
        /// Print the properties for this Node in a multi-line format
        /// </summary>
        /// <returns>
        /// Multi-Line <see cref="string"/> with a new line character at the end.
        /// </returns>
        public new string Print()
        {
            string retText = base.Print();
            retText += "Number of Textures: " + _nTextures + "\r\n";
            for (int i = 0; i < _nTextures; i++)
                retText += "    " + _Textures[i] + "\r\n";
            retText += "Script ID: " + _ScriptID + "\r\n";  
            return retText;
        }

        /// <summary>
        /// Debug Printing contains more data than the normal Print function.
        /// </summary>
        /// <returns>Multi-Line <see cref="string"/> with a new line at the end.</returns> 
        public new string DebugPrint()
        {
            string retText = base.DebugPrint();
            retText += "******** Root Node Data ********\r\n";
            retText += "(" + _lineCount + ") Texture IDs Pointer: " + _TexturePtr + " (" + (_TexturePtr + _RootPtr) + ")\r\n"; _lineCount += 4;
            retText += "(" + _lineCount + ") Number of Textures: " + _nTextures + "\r\n"; _lineCount += 4;
            retText += "(" + _lineCount + ") Script ID: " + _ScriptID + "\r\n"; _lineCount += 4;
            retText += "Textures: \r\n";
            for (int i = 0; i < _nTextures; i++)
                retText += "(" + (_RootPtr + _TexturePtr + (i * 4)) + ")     " + _Textures[i] + "\r\n";
            return retText;
        }

        /// <summary>
        /// Writes the <c>BSPNode</c> Data to the <see cref="Stream"/>.
        /// </summary>
        /// <returns><see cref="bool"/> <c>true</c> if successful or <c>false</c> if unsuccessful.</returns>
        /// <param name="stream"><see cref="Stream"/> Must be open and at the correct position prior to calling this function.</param>
        public new bool Save(Stream stream)
        {
            // This is the Root Node, so the Sibling should be -1
            _lastNode = -1;
            // Make sure all pointers are using this Node as the reference for their offsets
            UpdateRoot(stream.Position);
            // Write everything from the SubTree first
            base.Save(stream);
            // Write the Texture Data last
            try
            {
                using (BinaryWriter writer = new BinaryWriter(stream, System.Text.Encoding.Default, true))
                {
                    if (_nTextures >0)
                        foreach (int i in _Textures)
                        {
                            writer.Write(i);
                        }
                }

            }
            catch (Exception ex)
            {
                throw new Exception("An Error occurred writing the Root Node Data\r\n" + ex.Message, ex);
            }
            // There should never be anything with the Toot Node as a Sibling...but just in case
            _lastNode = _NodePtr;
            return true;
        }

        /// <summary>
        /// Returns a list of the Node Types for this Node and any SubTree Nodes.
        /// </summary>
        /// <returns></returns>
        public new List<int> GetNodeTypes()
        {
            return base.GetNodeTypes();
        }

        /// <summary>
        /// Updates the Root Pointer for the Node to reference.
        /// </summary>
        /// <param name="root"></param>
        public new void UpdateRoot(long root)
        {
            _RootPtr = _NodePtr = root;
            foreach (IBSPNode node in _SubTree)
                node.UpdateRoot(root);           
        }

        /// <summary>
        /// Helper function to read the Node from the file
        /// </summary>
        /// <param name="reader">BinaryReader</param>
        /// <remarks>reader must already be open and at the correct Position in the stream</remarks>
        private new int FillNode(BinaryReader reader)
        {
            //Read the Root Specific Data
            _TexturePtr = reader.ReadInt32();
            _nTextures = reader.ReadInt32();
            _ScriptID = reader.ReadInt32();

            // Fill the TextureID Array
            _Textures = GetTextureIDs(reader, _nTextures, reader.BaseStream.Position, _TexturePtr + _RootPtr);
            _Size += 12;
            return 1;
        }

        /// <summary>
        /// Helper Function to get the TextureIDs for this Root Node
        /// </summary>
        /// <param name="reader">BinaryReader</param>
        /// <remarks>reader must already be open and at the correct Position in the stream</remarks>
        /// <param name="count">The Number of Textures to read</param>
        /// <param name="returnAddress">The position of the File Stream to return to after the read is complete</param>
        /// <param name="dataAddress">The position in the file where the data is located</param>
        /// <returns>int[] Filled with Texture IDs</returns>
        private List<int> GetTextureIDs(BinaryReader reader, int count, long returnAddress, long dataAddress)
        {
            // Initialize a new Array to hold our pointers
            List<int> aTextures = new List<int>();

            // Seek to the File position for the data
            reader.BaseStream.Position = dataAddress;

            // Fill the list
            for (int i = 0; i < count; i++)
            {
                aTextures.Add(reader.ReadInt32());
            }

            // Return the reader to the correct position
            reader.BaseStream.Position = returnAddress;
            return aTextures;
        }
        #endregion
    }

    /// <summary>
    /// Slot Node.
    /// Inherits BNode.
    /// </summary>
    [Guid("422B94AC-5D1D-41CB-9F87-14B315904002")]
    public class BSlotNode : BNode, IBSPNode
    {
        #region Properties
        /// <summary>
        /// 3x3 Matrix of Floats to represent the Rotation Matrix.
        /// </summary>
        public float[,] RotationMatrix
        {
            get { return _RotationMatrix; }
            set { _RotationMatrix = value; }
        }
        /// <summary>
        /// System.Windows.Media.Media3D.Point3D object to represent the 3D Rotation Point.
        /// </summary>
        public System.Windows.Media.Media3D.Point3D RotationPoint
        {
            get { return _RotationPoint; }
            set { _RotationPoint = value; }
        }
        /// <summary>
        /// The Slot Id.
        /// </summary>
        public int SlotID
        {
            get { return _SlotID; }
            set { _SlotID = value; }
        }
        #endregion

        #region Fields
        private float[,] _RotationMatrix;
        private System.Windows.Media.Media3D.Point3D _RotationPoint;
        private int _SlotID;
        #endregion

        #region Constructors
        /// <summary>
        /// Returns an uninitialized object of type <see cref="BSlotNode"/>.
        /// </summary>
        public BSlotNode() : base()
        {
            _NodeType = NodeType.SlotNode;
            _VFT = (int)_NodeType;
            // Initialize the Local data
            _RotationMatrix = new float[3, 3];
            _RotationPoint = new System.Windows.Media.Media3D.Point3D();
            _SlotID = 0;
            _Size += 52;
        }

        /// <summary>
        /// Returns an object of type <see cref="BSlotNode"/>.
        /// </summary>
        /// <remarks>This Constructor should be used when reading from a LOD File.</remarks>
        /// <param name="stream"><see cref="Stream"/>;  Must be open and at the correct stream position prior to calling this function.</param>
        /// <param name="root">The file offset of the Root Node.</param>
        public BSlotNode(Stream stream, long root) : base(stream, root)
        {            
            _NodeType = NodeType.SlotNode;
            _VFT = (int)_NodeType;
            _RotationMatrix = new float[3, 3];
            try
            {
                using (BinaryReader reader = new BinaryReader(stream, System.Text.Encoding.Default, true))
                {
                    // Initialize the local data
                    FillNode(reader);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("There was an error reading the Slot Node at " + _NodePtr + "\r\n" + ex.Message, ex);
            }
        }
        #endregion

        #region Methods
        /// <summary>
        /// Print the properties for this Node in a multi-line format
        /// </summary>
        /// <returns>
        /// Multi-Line <see cref="string"/> with a new line character at the end.
        /// </returns> 
        public new string Print()
        {
            string retText = base.Print() + "Rotation Matrix: \r\n";
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    retText += _RotationMatrix[i, j] + "  ";
                }
                retText += "\r\n";
            }
            retText += "Rotation Point: (" + _RotationPoint.X + ", " + _RotationPoint.Y + ", " + _RotationPoint.Z + ")\r\n";
            retText += "Slot Number: " + _SlotID + "\r\n";
            return retText;
        }

        /// <summary>
        /// Debug Printing contains more data than the normal Print function.
        /// </summary>
        /// <returns>Multi-Line <see cref="string"/> with a new line at the end.</returns> 
        public new string DebugPrint()
        {
            string retText = base.DebugPrint();
            retText += "******** Slot Node Data ********\r\n";
            retText += "(" + _lineCount + " Rotation Matrix: \r\n";
            for (int i = 0; i < 3; i++)
            {
                retText += "(" + _lineCount + ") ";
                for (int j = 0; j < 3; j++)
                {
                    retText += _RotationMatrix[i, j] + "  "; _lineCount += 4;
                }
                retText += "\r\n";
            }
            retText += "(" + _lineCount + ") Rotation Point: (" + _RotationPoint.X + ", " + _RotationPoint.Y + ", " + _RotationPoint.Z + ")\r\n"; _lineCount += 12;
            retText += "(" + _lineCount + ") Slot ID: " + _SlotID + "\r\n"; _lineCount += 4;
            return retText;
        }

        /// <summary>
        /// Writes the <c>BSPNode</c> Data to the <see cref="Stream"/>.
        /// </summary>
        /// <returns><see cref="bool"/> <c>true</c> if successful or <c>false</c> if unsuccessful.</returns>
        /// <param name="stream"><see cref="Stream"/> Must be open and at the correct position prior to calling this function.</param>
        public new bool Save(Stream stream)
        {
            // Set the Node Pointer for use in the Sibling calculation for the next node
            _NodePtr = stream.Position - _RootPtr;
            // Write the generic BNode Data
            base.Save(stream);
            // Write the Slot Data
            try
            {
                using (BinaryWriter writer = new BinaryWriter(stream, System.Text.Encoding.Default, true))
                {
                    for (int i = 0; i < 3; i++)
                        for (int j = 0; j < 3; j++)
                            writer.Write(_RotationMatrix[i, j]);
                    writer.Write((Single)_RotationPoint.X);
                    writer.Write((Single)_RotationPoint.Y);
                    writer.Write((Single)_RotationPoint.Z);
                    writer.Write(_SlotID);
                }
                    
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while writing the Slot Node at " + _NodePtr + "\r\n" + ex.Message, ex);
            }
            // Update the Static Sibling pointer to this node
            _lastNode = _NodePtr;
            return true;
        }

        /// <summary>
        /// Helper function to read the data for this node
        /// </summary>
        /// <param name="reader">BinaryReader</param>
        /// <remarks>Binary Reader must be open and at the correct position</remarks>
        private new int FillNode(BinaryReader reader)
        {
            // Fill the 3x3 Matrix
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    _RotationMatrix[i, j] = reader.ReadSingle();
                }
            }

            // Get the Rotation Point
            _RotationPoint = new System.Windows.Media.Media3D.Point3D(reader.ReadSingle(), reader.ReadSingle(), reader.ReadSingle());

            // Read the Slot ID
            _SlotID = reader.ReadInt32();
            _Size += 52;
            if (_SlotID < 0)
                throw new Exception("Invalid Slot ID");
            return 1;
        }
        #endregion
    }

    /// <summary>
    /// Degree Of Freedom (DOF) Node.
    /// Inherits BSubtree.
    /// </summary>
    [Guid("9B817D91-2897-49B8-AAFC-09105649D7CF")]
    public class BDOFNode : BSubTreeNode, IBSPNode
    {
        #region Properties
        /// <summary>
        /// The DOF ID.
        /// </summary>
        public DOFID DOFID
        {
            get { return (DOFID)_DOFID; }
            set { _DOFID = (int)value; }
        }        
        /// <summary>
        /// 3x3 Matrix of Floats to represent the rotation matrix.
        /// </summary>
        public float[,] RotationMatrix
        {
            get { return _RotationMatrix; }
            set { _RotationMatrix = value; }
        }
        /// <summary>
        /// System.Windows.Media.Media3D.Point3D object to represent the 3D position of the rotation.
        /// </summary>
        public System.Windows.Media.Media3D.Point3D RotationPoint
        {
            get { return _RotationPoint; }
            set { _RotationPoint = value; }
        }
        /// <summary>
        /// The Total Size of the Node including all extra data and SubTrees.
        /// </summary>
        public new int TotalSize
        {
            get
            {
                return base.TotalSize;
            }
        }
        /// <summary>
        /// Read-Only Count of the Number of <c>BSPNode</c> objects this Node represents including SubTrees.
        /// </summary>
        public new int NodeCount
        {
            get
            {
                return base.NodeCount;
            }
        }
        /// <summary>
        /// The offset of this Node relative to the Root Node.
        /// </summary>
        public new long NodeAddress
        {
            get { return _NodePtr; }
            set {
                _NodePtr = value;                
            }
        }
        #endregion

        #region Fields
        private int _DOFID;
        private float[,] _RotationMatrix;
        private System.Windows.Media.Media3D.Point3D _RotationPoint;
        #endregion

        #region Constructors
        /// <summary>
        /// Returns an uninitialized object of type <see cref="BDOFNode"/>.
        /// </summary>
        public BDOFNode() : base()
        {
            _NodeType = NodeType.DOFNode;
            _VFT = (int)_NodeType;
            // Initialize the local data
            _DOFID = 0;
            _RotationMatrix = new float[3, 3];
            _RotationPoint = new System.Windows.Media.Media3D.Point3D();            
            _Size += 52;
        }

        /// <summary>
        /// Returns an object of type <see cref="BDOFNode"/>.
        /// </summary>
        /// <remarks>This Constructor should be used when reading from a LOD File.</remarks>
        /// <param name="stream"><see cref="Stream"/>;  Must be open and at the correct stream position prior to calling this function.</param>
        /// <param name="root">The file offset of the Root Node.</param>
        public BDOFNode(Stream stream, long root) : base(stream, root)
        {            
            _NodeType = NodeType.DOFNode;
            _VFT = (int)_NodeType;
            _RotationMatrix = new float[3, 3];
            try
            {
                using (BinaryReader reader = new BinaryReader(stream, System.Text.Encoding.Default, true))
                {
                    // Fill the Node Data
                    FillNode(reader);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("There was an error while reading the DOF Node at " + _NodePtr + "\r\n" + ex. Message, ex);
            }
        }
        #endregion

        #region Methods
        /// <summary>
        /// Print the properties for this Node in a multi-line format
        /// </summary>
        /// <returns>
        /// Multi-Line <see cref="string"/> with a new line character at the end.
        /// </returns> 
        public new string Print()
        {
            string retText = base.Print();
            retText += "DOF ID: " + _DOFID + "\r\nRotation Matrix:\r\n";
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    retText += _RotationMatrix[i, j] + "  ";
                }
                retText += "\r\n";
            }
            retText += "Rotation Point: (" + _RotationPoint.X + ", " + _RotationPoint.Y + ", " + _RotationPoint.Z + ")\r\n";
            return retText;
        }

        /// <summary>
        /// Debug Printing contains more data than the normal Print function.
        /// </summary>
        /// <returns>Multi-Line <see cref="string"/> with a new line at the end.</returns> 
        public new string DebugPrint()
        {
            string retText = base.DebugPrint();
            retText += "******** DOF Node Data********\r\n";
            retText += "(" + _lineCount + ") DOF ID: " + _DOFID + "\r\nRotation Matrix:\r\n"; _lineCount += 4;
            for (int i = 0; i < 3; i++)
            {
                retText += "(" + _lineCount + ")";
                for (int j = 0; j < 3; j++)
                {
                    retText += "   " + _RotationMatrix[i, j] + "  "; _lineCount += 4;
                }
                retText += "\r\n";
            }
            retText += "(" + _lineCount + ") Rotation Point: (" + _RotationPoint.X + ", " + _RotationPoint.Y + ", " + _RotationPoint.Z + ")\r\n"; _lineCount += 12;
            return retText;
        }

        /// <summary>
        /// Writes the <c>BSPNode</c> Data to the <see cref="Stream"/>.
        /// </summary>
        /// <returns><see cref="bool"/> <c>true</c> if successful or <c>false</c> if unsuccessful.</returns>
        /// <param name="stream"><see cref="Stream"/> Must be open and at the correct position prior to calling this function.</param>
        public new bool Save(Stream stream)
        {
            base.Save(stream);
            // Values written in SubTree Save 
            return true;
        }

        /// <summary>
        /// Returns a list of the Node Types for this Node and any SubTree Nodes.
        /// </summary>
        /// <returns></returns>
        public new List<int> GetNodeTypes()
        {
            return base.GetNodeTypes();
        }

        /// <summary>
        /// Helper function to read the data for this node
        /// </summary>
        /// <param name="reader">BinaryReader</param>
        /// <remarks>Binary Reader must be open and at the correct position</remarks>
        private new int FillNode(BinaryReader reader)
        {
            // Fill the DOF specific data
            // Read the DOF ID
            _DOFID = reader.ReadInt32();
            // Fill the 3x3 Matrix
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    _RotationMatrix[i, j] = reader.ReadSingle();
                }
            }

            // Get the Rotation Point
            _RotationPoint = new System.Windows.Media.Media3D.Point3D(reader.ReadSingle(), reader.ReadSingle(), reader.ReadSingle());

            _Size += 52;
            return 1;
        }       
        #endregion
    }

    /// <summary>
    /// Switch Node.
    /// Inherits BNode.
    /// </summary>
    [Guid("41E8B540-4B95-4EEC-BB41-C0DDF7E761CB")]
    public class BSwitchNode : BNode, IBSPNode
    {
        #region Properties
        /// <summary>
        /// The Switch ID Number
        /// </summary>
        public SwitchID SwitchID
        {
            get { return (SwitchID)_Switch; }
            set { _Switch = (int)value; }
        }
        /// <summary>
        /// The File Offset relative to the Root Node where the SubTree exists.  The Node at this location will be processed after the current node.
        /// </summary>
        public long SubTreePointer
        {
            get { return _SubtreePtr; }
            set { _SubtreePtr = value; }
        }
        /// <summary>
        /// Number of children elements dependent upon this Switch.
        /// </summary>
        public int ChildCount
        {
            get { return _SubTrees.Count; }            
        }
        /// <summary>
        /// List of the Child Subtres for this Switch
        /// </summary>
        public List<long> ChildrenPointers
        {
            get { return _ChildrenPtrs; }
            set
            {
                _ChildrenPtrs = value;
                _nChildren = _ChildrenPtrs.Count;
            }
        }
        /// <summary>
        /// Collection of BSPNodes which make up the SubTree.
        /// </summary>
        public List<IBSPNode> SubTrees
        {
            get { return _SubTrees; }
            set
            {
                _SubTrees = value;
                _nChildren = _SubTrees.Count;                
            }
        }
        /// <summary>
        /// The Total Size of the Node including all extra data and SubTrees.
        /// </summary>
        public new int TotalSize
        {
            get
            {
                int size = _Size;
                foreach (IBSPNode node in _SubTrees)
                    size += node.TotalSize;
                return size;
            }            
        }
        /// <summary>
        /// Read-Only Count of the Number of <c>BSPNode</c> objects this Node represents including SubTrees.
        /// </summary>
        public new int NodeCount
        {
            get
            {
                int count = 1;
                foreach (IBSPNode node in _SubTrees)
                    count += node.NodeCount;
                return count;
            }
        }
        /// <summary>
        /// The offset of this Node relative to the Root Node.
        /// </summary>
        public new long NodeAddress
        {
            get { return _NodePtr; }
            set
            {
                _NodePtr = value;                
            }
        }
        #endregion

        #region Fields
        private int _nChildren;
        private long _SubtreePtr;
        private int _Switch;
        private List<long> _ChildrenPtrs;
        private List<IBSPNode> _SubTrees;
        #endregion

        #region Constructors
        /// <summary>
        /// Returns an uninitialized object of type <see cref="BSwitchNode"/>.
        /// </summary>
        public BSwitchNode() : base()
        {
            _nChildren = 0;
            _SubtreePtr = -1;
            _Switch = 0;
            _NodeType = NodeType.SwitchNode;
            _VFT = (int)_NodeType;
            _SubTrees = new List<IBSPNode>();
            _Size += 12;
        }

        /// <summary>
        /// Returns an object of type <see cref="BSwitchNode"/>.
        /// </summary>
        /// <remarks>This Constructor should be used when reading from a LOD File.</remarks>
        /// <param name="stream"><see cref="Stream"/>;  Must be open and at the correct stream position prior to calling this function.</param>
        /// <param name="root">The file offset of the Root Node.</param>
        public BSwitchNode(Stream stream, long root) : base(stream, root)
        {
            
            _NodeType = NodeType.SwitchNode;
            _VFT = (int)_NodeType;
            _SubTrees = new List<IBSPNode>();
            try
            {
                using (BinaryReader reader = new BinaryReader(stream, System.Text.Encoding.Default, true))
                {
                    FillNode(reader); 
                }
            }
            catch (Exception ex)
            {
                throw new Exception("There was an error while reading the Switch Node at " + _NodePtr + "\r\n" + ex.Message, ex);
            }
        }
        #endregion

        #region Methods
        /// <summary>
        /// Print the properties for this Node in a multi-line format
        /// </summary>
        /// <returns>
        /// Multi-Line <see cref="string"/> with a new line character at the end.
        /// </returns> 
        public new string Print()
        {
            string retText = base.Print();
            retText += "Switch Number: " + _Switch + "\r\n";
            retText += "Children:\r\n";
            for (int i = 0; i < _ChildrenPtrs.Count; i++)
                retText += "    Child " + i + ":" + _ChildrenPtrs[i] + "\r\n";
            foreach (IBSPNode node in _SubTrees)
                retText += node.Print();
            return retText;
        }

        /// <summary>
        /// Debug Printing contains more data than the normal Print function.
        /// </summary>
        /// <returns>Multi-Line <see cref="string"/> with a new line at the end.</returns> 
        public new string DebugPrint()
        {
            string retText = base.DebugPrint();
            retText += "******** Switch Node Data ********\r\n";
            retText += "(" + _lineCount + ") Switch Number: " + _Switch + "\r\n"; _lineCount += 4;
            retText += "(" + _lineCount + ") Number of Children: " + _nChildren + "\r\n"; _lineCount += 4;
            retText += "(" + _lineCount + ") SubTree Pointer: " + _SubtreePtr + " (" + (_SubtreePtr + _RootPtr) + ")\r\n"; _lineCount += 4;
            retText += "Children:\r\n";
            for (int i = 0; i < _ChildrenPtrs.Count; i++)
                retText += "(" + ((_SubtreePtr + _RootPtr) + (4 * i)) + ")    Child " + i + ": " + _ChildrenPtrs[i] + " (" + (_RootPtr + _ChildrenPtrs[i]) + ")\r\n";
            foreach (IBSPNode node in _SubTrees)
                retText += node.DebugPrint();
            return retText;
        }

        /// <summary>
        /// Writes the <c>BSPNode</c> Data to the <see cref="Stream"/>.
        /// </summary>
        /// <returns><see cref="bool"/> <c>true</c> if successful or <c>false</c> if unsuccessful.</returns>
        /// <param name="stream"><see cref="Stream"/> Must be open and at the correct position prior to calling this function.</param>
        public new bool Save(Stream stream)
        {
            _NodePtr = stream.Position - _RootPtr;
            UpdatePointers();
            base.Save(stream);
            
            try
            {
                using (BinaryWriter writer = new BinaryWriter(stream, System.Text.Encoding.Default, true))
                {
                    writer.Write(_Switch);
                    writer.Write(_nChildren);
                    writer.Write((int)_SubtreePtr);
                    foreach (long i in _ChildrenPtrs)
                        writer.Write((int)i);
                    
                    foreach (IBSPNode node in _SubTrees)
                    {
                        _lastNode = -1;
                        node.Save(writer.BaseStream);
                    }
                        
                }
            }
            catch (Exception ex)
            {
                throw new Exception("There was an error while writing the Switch Node at " + _NodePtr + "\r\n" + ex.Message, ex);
            }
            _lastNode = _NodePtr;
            return true;
        }

        /// <summary>
        /// Returns a list of the Node Types for this Node and any SubTree Nodes.
        /// </summary>
        /// <returns></returns>
        public new List<int> GetNodeTypes()
        {
            List<int> nodetypes = new List<int>
            {
                (int)_NodeType
            };
            foreach (IBSPNode node in _SubTrees)
                nodetypes.AddRange(node.GetNodeTypes());
            return nodetypes;
        }

        /// <summary>
        /// Updates the Root Pointer for the Node to reference.
        /// </summary>
        /// <param name="root"></param>
        public new void UpdateRoot(long root)
        {
            _RootPtr = root;
            foreach (IBSPNode node in SubTrees)
                node.UpdateRoot(root);            
        }

        /// <summary>
        /// Updates Sizes and Pointers for the Node and SubTree Nodes 
        /// </summary>
        private void UpdatePointers()
        {
            // Set the SubTreePointer
            _SubtreePtr = _NodePtr + 20;            
            // Update the List of Child Pointers
            for (int i = 0; i < _nChildren; i++)
            {
                if (i == 0)
                {
                    _ChildrenPtrs[i] = (_SubtreePtr + (4 * _nChildren));
                }
                else
                {
                    _ChildrenPtrs[i] = (_ChildrenPtrs[i-1]) + _SubTrees[i - 1].TotalSize;
                }
                _SubTrees[i].NodeAddress = _ChildrenPtrs[i];
            }
                
        }

        /// <summary>
        /// Helper function to read the data for this node
        /// </summary>
        /// <param name="reader">BinaryReader</param>
        /// <remarks>Binary Reader must be open and at the correct position</remarks>
        private new int FillNode(BinaryReader reader)
        {
            // Fill the Switch specific data
            _Switch = reader.ReadInt32();
            _nChildren = reader.ReadInt32();
            _SubtreePtr = reader.ReadInt32();

            // Get the Children Pointers
            _ChildrenPtrs = new List<long>();
            if (_nChildren > 0)
            {
                long returnPtr = reader.BaseStream.Position;
                reader.BaseStream.Position = _SubtreePtr + _RootPtr;
                for (int i = 0; i < _nChildren; i++)
                    _ChildrenPtrs.Add(reader.ReadInt32());
            }

            _Size += (12 + (4 * _nChildren));

            return 1;
        }
        #endregion
    }

    /// <summary>
    /// Splitter Node.
    /// Inherits BNode.
    /// </summary>
    [Guid("6F11B1C1-F113-48AC-91F3-372B21E4159C")]
    public class BSplitterNode : BNode, IBSPNode
    {
        #region Properties
        /// <summary>
        /// Splitter Node A Component.  The I Component of a Normal.
        /// </summary>
        public float A
        {
            get { return _A; }
            set { _A = value; }
        }
        /// <summary>
        /// Splitter Node B Component.  The J Component of a Normal.
        /// </summary>
        public float B
        {
            get { return _B; }
            set { _B = value; }
        }
        /// <summary>
        /// Splitter Node C Component.  The K Component of a Normal.
        /// </summary>
        public float C
        {
            get { return _C; }
            set { _C = value; }
        }
        /// <summary>
        /// Splitter Node D Component.  The distance offset in a split plane calculation.
        /// </summary>
        public float D
        {
            get { return _D; }
            set { _D = value; }
        }
        /// <summary>
        /// The Front SubTree File OFfset relative to the Root Node for this Splitter Node.
        /// </summary>
        public long FrontNodePointer
        {
            get { return _FrontNodePointer; }
            set { _FrontNodePointer = value; }
        }
        /// <summary>
        /// The Back SubTree File OFfset relative to the Root Node for this Splitter Node.
        /// </summary>
        public long BackNodePointer
        {
            get { return _BackNodePointer; }
            set { _BackNodePointer = value; }
        }
        /// <summary>
        /// Collection of BSPNodes which make up the Front Tree of this Splitter.
        /// </summary>
        public List<IBSPNode> FrontNode
        {
            get { return _FrontTree; }
            set { _FrontTree = value; }
        }
        /// <summary>
        /// Collection of BSPNodes which make up the Back Tree of this Splitter.
        /// </summary>
        public List<IBSPNode> BackNode
        {
            get { return _BackTree; }
            set { _BackTree = value; }
        }
        /// <summary>
        /// The Total Size of the Node including all extra data and SubTrees.
        /// </summary>
        public new int TotalSize
        {
            get
            {
                int size = _Size;
                foreach (IBSPNode node in FrontNode.Concat(BackNode))
                    size += node.TotalSize;
                return size;
            }
        }
        /// <summary>
        /// Read-Only Count of the Number of <c>BSPNode</c> objects this Node represents including SubTrees.
        /// </summary>
        public new int NodeCount
        {
            get
            {
                int count = 1;
                foreach (IBSPNode node in _FrontTree.Concat(_BackTree))
                    count += node.NodeCount;
                return count;
            }
        }
        /// <summary>
        /// The offset of this Node relative to the Root Node.
        /// </summary>
        public new long NodeAddress
        {
            get { return _NodePtr; }
            set
            {
                _NodePtr = value;
            }
        }
        #endregion

        #region Fields
        private float _A;  // Normal I
        private float _B;  // Normal J
        private float _C;  // Normal K
        private float _D;  // Scaling/Offset distance
        private long _FrontNodePointer;
        private long _BackNodePointer;
        private List<IBSPNode> _FrontTree;
        private List<IBSPNode> _BackTree;
        #endregion

        #region Constructors
        /// <summary>
        /// Returns an uninitialized object of type <see cref="BSplitterNode"/>.
        /// </summary>
        public BSplitterNode() : base()
        {
            _A = _B = _C = _D = 0;
            _FrontNodePointer = _BackNodePointer = 0;
            _NodeType = NodeType.SplitterNode;
            _VFT = (int)_NodeType;
            _FrontTree = new List<IBSPNode>();
            _BackTree = new List<IBSPNode>();
            _Size += 24;
        }

        /// <summary>
        /// Returns an object of type <see cref="BSplitterNode"/>.
        /// </summary>
        /// <remarks>This Constructor should be used when reading from a LOD File.</remarks>
        /// <param name="stream"><see cref="Stream"/>;  Must be open and at the correct stream position prior to calling this function.</param>
        /// <param name="root">The file offset of the Root Node.</param>
        public BSplitterNode(Stream stream, long root) : base(stream, root)
        {
            
            _NodeType = NodeType.SplitterNode;
            _VFT = (int)_NodeType;
            _FrontTree = new List<IBSPNode>();
            _BackTree = new List<IBSPNode>();
            try
            {
                using (BinaryReader reader = new BinaryReader(stream, System.Text.Encoding.Default, true))
                {
                    // Fill the node
                    FillNode(reader);
                }
            }
            catch (Exception ex)
            {

                throw new Exception("There was an error while loading the Split Node at "+_NodePtr + "\r\n" + ex.Message, ex);
            }
        }
        #endregion

        #region Methods
        /// <summary>
        /// Print the properties for this Node in a multi-line format
        /// </summary>
        /// <returns>
        /// Multi-Line <see cref="string"/> with a new line character at the end.
        /// </returns> 
        public new string Print()
        {
            string retText = base.Print();
            retText += "A: " + _A + "\r\n";
            retText += "B: " + _B + "\r\n";
            retText += "C: " + _C + "\r\n";
            retText += "D: " + _D + "\r\n";
            retText += "Front BNode Pointer: " + _FrontNodePointer + "\r\n";
            retText += "Back BNode Pointer: " + _BackNodePointer + "\r\n";
            foreach (IBSPNode node in _FrontTree)
                retText += node.Print();
            foreach (IBSPNode node in _BackTree)
                retText += node.Print();
            return retText;
        }

        /// <summary>
        /// Debug Printing contains more data than the normal Print function.
        /// </summary>
        /// <returns>Multi-Line <see cref="string"/> with a new line at the end.</returns> 
        public new string DebugPrint()
        {
            string retText = base.DebugPrint();
            retText += "******** Spliiter Node Data ********\r\n";
            retText += "(" + _lineCount + ") A: " + _A + "\r\n"; _lineCount += 4;
            retText += "(" + _lineCount + ") B: " + _B + "\r\n"; _lineCount += 4;
            retText += "(" + _lineCount + ") C: " + _C + "\r\n"; _lineCount += 4;
            retText += "(" + _lineCount + ") D: " + _D + "\r\n"; _lineCount += 4;
            retText += "(" + _lineCount + ") Front BNode Pointer: " + _FrontNodePointer + " (" + (_RootPtr + _FrontNodePointer) + ")\r\n"; _lineCount += 4;
            retText += "(" + _lineCount + ") Back BNode Pointer: " + _BackNodePointer + " (" + (_RootPtr + _BackNodePointer) + ")\r\n"; _lineCount += 4;
            foreach (IBSPNode node in _FrontTree)
                retText += node.DebugPrint();
            foreach (IBSPNode node in _BackTree)
                retText += node.DebugPrint();
            return retText;
        }

        /// <summary>
        /// Writes the <c>BSPNode</c> Data to the <see cref="Stream"/>.
        /// </summary>
        /// <returns><see cref="bool"/> <c>true</c> if successful or <c>false</c> if unsuccessful.</returns>
        /// <param name="stream"><see cref="Stream"/> Must be open and at the correct position prior to calling this function.</param>
        public new bool Save(Stream stream)
        {
            _NodePtr = stream.Position - _RootPtr;
            UpdatePointers();
            base.Save(stream);
            
            try
            {
                using (BinaryWriter writer = new BinaryWriter(stream, System.Text.Encoding.Default, true))
                {
                    writer.Write(_A);
                    writer.Write(_B);
                    writer.Write(_C);
                    writer.Write(_D);
                    if (_FrontTree.Count > 0)
                        writer.Write((int)_FrontNodePointer);
                    else
                        writer.Write(-1);
                    if (_BackTree.Count > 0)
                        writer.Write((int)_BackNodePointer);
                    else
                        writer.Write(-1);
                    _lastNode = -1;
                    if (_FrontTree.Count >0)
                        for (int i = _FrontTree.Count-1;i>=0;i--)
                            _FrontTree[i].Save(writer.BaseStream);

                    _lastNode = -1;
                    if (_BackTree.Count > 0)
                        for (int i = _BackTree.Count - 1; i >= 0; i--)
                            _BackTree[i].Save(writer.BaseStream);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("There was an error while writing the Split Node at " + _NodePtr + "\r\n" + ex.Message, ex);
            }
            _lastNode = _NodePtr;
            return true;
        }
        
        /// <summary>
        /// Returns a list of the Node Types for this Node and any SubTree Nodes.
        /// </summary>
        /// <returns></returns>
        public new List<int> GetNodeTypes()
        {
            List<int> nodetypes = new List<int>
            {
                (int)_NodeType
            };
            foreach (IBSPNode node in _FrontTree.Concat(_BackTree))
                nodetypes.AddRange(node.GetNodeTypes());
            return nodetypes;
        }

        /// <summary>
        /// Updates the Root Pointer for the Node to reference.
        /// </summary>
        /// <param name="root"></param>
        public new void UpdateRoot(long root)
        {
            _RootPtr = root;
            foreach (IBSPNode node in _FrontTree.Concat(_BackTree))
                node.UpdateRoot(root);           
        }

        /// <summary>
        /// Helper function to read the data for this node
        /// </summary>
        /// <param name="reader">BinaryReader</param>
        /// <remarks>Binary Reader must be open and at the correct position</remarks>
        private new int FillNode(BinaryReader reader)
        {
            // Fill the Splitter specific data
            _A = reader.ReadSingle();
            _B = reader.ReadSingle();
            _C = reader.ReadSingle();
            _D = reader.ReadSingle();
            _FrontNodePointer = reader.ReadInt32();
            _BackNodePointer = reader.ReadInt32();

            _Size += 24;
            return -1;
        }

        /// <summary>
        /// Updates Sizes and Pointers for the Node and SubTree Nodes 
        /// </summary>
        private void UpdatePointers()
        {
            // Set the SubTreePointers            
            int _TreeSize = 0;             
            if (_FrontTree.Count > 0)
            {
                foreach (IBSPNode node in _FrontTree)
                    _TreeSize += node.TotalSize;
                _FrontNodePointer = _NodePtr + 32 + (_TreeSize - _FrontTree[0].TotalSize);                
                _FrontTree[0].NodeAddress = _FrontNodePointer;
            }
            else
                _FrontNodePointer = -1;

            if (_BackTree.Count > 0)
            {
                _BackNodePointer = _NodePtr + 32 + _TreeSize;
                _TreeSize = 0;
                foreach (IBSPNode node in _BackTree)
                    _TreeSize += node.TotalSize;
                _BackNodePointer += _TreeSize - _BackTree[0].TotalSize;
                _BackTree[0].NodeAddress = _BackNodePointer;
            }
            else
                _BackNodePointer = -1;
        }
        #endregion
    }

    /// <summary>
    /// Primitive Node.
    /// Inherits BNode.
    /// </summary>
    [Guid("8701D7F3-6AE6-441C-B767-A226224CFC42")]
    public class BPrimitiveNode : BNode, IBSPNode
    {
        #region Properties
        /// <summary>
        /// Read-Only type of Polygon this Primitive Node contains.
        /// </summary>
        public PolyType PolygonType
        { get { return _Prim.PolygonType; } }
        /// <summary>
        /// The F4BMS.Primitive object this Node contains.
        /// </summary>
        public IPrimitive Primitive
        {
            get { return _Prim; }
            set { _Prim = value; }
        }
        /// <summary>
        /// The offset of this Node relative to the Root Node.
        /// </summary>
        public new long NodeAddress
        {
            get { return _NodePtr; }
            set
            {
                _NodePtr = value;            
            }
        }
        #endregion

        #region Fields
        /// <summary>
        /// The File Offset tot he Primitive Object.
        /// </summary>
        protected long _PrimPtr;
        /// <summary>
        ///  The Primitive Object.
        /// </summary>
        protected IPrimitive _Prim;
        #endregion

        #region Constructors
        /// <summary>
        /// Returns an uninitialized object of type <see cref="BPrimitiveNode"/>.
        /// </summary>
        public BPrimitiveNode() : base()
        {
            _NodeType = NodeType.PrimitiveNode;
            _VFT = (int)_NodeType;
            _PrimPtr = 0;
            _Prim = null;
            _Size += 4;
        }

        /// <summary>
        /// Returns an object of type <see cref="BPrimitiveNode"/>.
        /// </summary>
        /// <remarks>This Constructor should be used when reading from a LOD File.</remarks>
        /// <param name="stream"><see cref="Stream"/>;  Must be open and at the correct stream position prior to calling this function.</param>
        /// <param name="root">The file offset of the Root Node.</param>
        public BPrimitiveNode(Stream stream, long root) : base(stream, root)
        {
            _NodeType = NodeType.PrimitiveNode;
            _VFT = (int)_NodeType;
            try
            {
                using (BinaryReader reader = new BinaryReader(stream, System.Text.Encoding.Default, true))
                {
                    // Fill the node
                    FillNode(reader);
                }
            }
            catch (Exception ex)
            {

                throw new Exception("There was an error reading the Primitive Node at " + _NodePtr + "\r\n" + ex.Message, ex);
            } 
        }
        #endregion

        #region Methods
        /// <summary>
        /// Print the properties for this Node in a multi-line format
        /// </summary>
        /// <returns>
        /// Multi-Line <see cref="string"/> with a new line character at the end.
        /// </returns> 
        public new string Print()
        {
            string retText = base.Print();
            retText += _Prim.Print();
            return retText;
        }

        /// <summary>
        /// Debug Printing contains more data than the normal Print function.
        /// </summary>
        /// <returns>Multi-Line <see cref="string"/> with a new line at the end.</returns> 
        public new string DebugPrint()
        {
            string retText = base.DebugPrint();
            retText += "******** Primitive Node Data ********\r\n";
            retText += "(" + _lineCount + ") Primitive Pointer: " + _PrimPtr + " (" + (_RootPtr + _PrimPtr) + ") \r\n"; _lineCount += 4;
            retText += _Prim.DebugPrint();
            return retText;
        }

        /// <summary>
        /// Writes the <c>BSPNode</c> Data to the <see cref="Stream"/>.
        /// </summary>
        /// <returns><see cref="bool"/> <c>true</c> if successful or <c>false</c> if unsuccessful.</returns>
        /// <param name="stream"><see cref="Stream"/> Must be open and at the correct position prior to calling this function.</param>
        public new bool Save(Stream stream)
        {
            _NodePtr = stream.Position - _RootPtr;
            UpdatePointers();
            base.Save(stream);
            try
            {
                using (BinaryWriter writer = new BinaryWriter(stream, System.Text.Encoding.Default, true))
                {
                    writer.Write((int)_PrimPtr);
                    if (_NodeType == NodeType.PrimitiveNode)
                        _Prim.Save(writer.BaseStream);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("There was an error while writing the Primitive Node at " + _NodePtr + "\r\n" + ex.Message, ex);
            }
            _lastNode = _NodePtr;
            return true;
        }

        /// <summary>
        /// Updates the Root Pointer for the Node to reference.
        /// </summary>
        /// <param name="root"></param>
        public new void UpdateRoot(long root)
        {
            _RootPtr = root;
            _Prim.UpdateRoot(root);
        }

        /// <summary>
        /// Helper function to read the data for this node
        /// </summary>
        /// <param name="reader">BinaryReader</param>
        /// <remarks>Binary Reader must be open and at the correct position</remarks>
        private new int FillNode(BinaryReader reader)
        {
            // Get the Prim Pointer
            _PrimPtr = reader.ReadInt32();

            // Get the Prim information
            reader.BaseStream.Position = _PrimPtr + _RootPtr;
            _Prim = LoadPrim(reader.BaseStream);

            _Size += 4 + _Prim.Size;
            return 1;
        }

        /// <summary>
        /// Updates Sizes and Pointers for the Node and SubTree Nodes 
        /// </summary>
        private void UpdatePointers()
        {
            _PrimPtr = _NodePtr + 12;            
        }
        #endregion
    }

    /// <summary>
    /// Lit Primitive Node.
    /// Inherits BNode.
    /// </summary>
    [Guid("D7CC75E1-50D6-4A39-9031-F5C320017B4C")]
    public class BLitPrimitiveNode : BNode, IBSPNode
    {
        #region Properties
        /// <summary>
        /// Read-Only type of Polygon this Primitive Node contains.
        /// </summary>
        public PolyType PolygonType
        { get { return _PrimFront.PolygonType; } }
        /// <summary>
        /// The F4BMS.Primitive object this Node uses for the front of the Lit Primitive.
        /// </summary>
        public IPrimitive FrontPrimitive
        {
            get { return _PrimFront; }
            set {
                _PrimFront = value;               
            }
        }
        /// <summary>
        /// The F4BMS.Primitive object this Node uses for the back of the Lit Primitive.
        /// </summary>
        public IPrimitive BackPrimitive
        {
            get { return _PrimBack; }
            set { _PrimBack = value; }
        }
        /// <summary>
        /// The offset of this Node relative to the Root Node.
        /// </summary>
        public new long NodeAddress
        {
            get { return _NodePtr; }
            set
            {
                _NodePtr = value;
            }
        }
        #endregion

        #region Fields
        long _PrimPtrFront;
        IPrimitive _PrimFront;
        long _PrimPtrBack;
        IPrimitive _PrimBack;
        #endregion

        #region Constructors
        /// <summary>
        /// Returns an uninitialized object of type <see cref="BLitPrimitiveNode"/>.
        /// </summary>
        public BLitPrimitiveNode() : base()
        {
            //  Initialize();
            _NodeType = NodeType.LitPrimitiveNode;
            _VFT = (int)_NodeType;
            _Size += 8;

        }

        /// <summary>
        /// Returns an object of type <see cref="BLitPrimitiveNode"/>.
        /// </summary>
        /// <remarks>This Constructor should be used when reading from a LOD File.</remarks>
        /// <param name="stream"><see cref="Stream"/>;  Must be open and at the correct stream position prior to calling this function.</param>
        /// <param name="root">The file offset of the Root Node.</param>
        public BLitPrimitiveNode(Stream stream, long root) : base(stream, root)
        {
            
            _NodeType = NodeType.LitPrimitiveNode;
            _VFT = (int)_NodeType;
            try
            {
                using (BinaryReader reader = new BinaryReader(stream, System.Text.Encoding.Default, true))
                {
                    FillNode(reader); 
                }
            }
            catch (Exception ex)
            {

                throw new Exception("There was an error reading Lit Primitive Node at " + _NodePtr + "\r\n" + ex.Message, ex);
            }
        }
        #endregion

        #region Methods
        /// <summary>
        /// Print the properties for this Node in a multi-line format
        /// </summary>
        /// <returns>
        /// Multi-Line <see cref="string"/> with a new line character at the end.
        /// </returns> 
        public new string Print()
        {
            string retText = base.Print();
            retText += "Front Primitive:\r\n";
            retText += _PrimFront.Print() + "\r\n";
            retText += "Back Primitive:\r\n";
            retText += _PrimBack.Print() + "\r\n";
            return retText;
        }

        /// <summary>
        /// Debug Printing contains more data than the normal Print function.
        /// </summary>
        /// <returns>Multi-Line <see cref="string"/> with a new line at the end.</returns> 
        public new string DebugPrint()
        {
            string retText = base.DebugPrint();
            retText += "******** Lit Primitive Node Data ********\r\n";
            retText += "(" + _lineCount + ") Front Pointer:" + _PrimPtrFront + " (" + (_RootPtr + _PrimPtrFront) + ")\r\n"; _lineCount += 4;
            retText += "(" + _lineCount + ") Back Pointer:" + _PrimPtrBack + " (" + (_RootPtr + _PrimPtrBack) + ")\r\n"; _lineCount += 4;
            retText += "Front Primitive:\r\n";
            retText += _PrimFront.DebugPrint();
            retText += "Back Primitive:\r\n";
            retText += _PrimBack.DebugPrint();
            return retText;
        }

        /// <summary>
        /// Writes the <c>BSPNode</c> Data to the <see cref="Stream"/>.
        /// </summary>
        /// <returns><see cref="bool"/> <c>true</c> if successful or <c>false</c> if unsuccessful.</returns>
        /// <param name="stream"><see cref="Stream"/> Must be open and at the correct position prior to calling this function.</param>
        public new bool Save(Stream stream)
        {
            _NodePtr = stream.Position - _RootPtr;
            UpdatePointers();
            base.Save(stream);
            try
            {
                using (BinaryWriter writer = new BinaryWriter(stream, System.Text.Encoding.Default, true))
                {
                    writer.Write((int)_PrimPtrFront);
                    writer.Write((int)_PrimPtrBack);
                    _PrimFront.Save(writer.BaseStream);
                    _PrimBack.Save(writer.BaseStream);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("There was an error while writing the Lit Primitive Node at " + _NodePtr + "\r\n" + ex.Message, ex);
            }
            _lastNode = _NodePtr;
            return true;
        }

        /// <summary>
        /// Updates the Root Pointer for the Node to reference.
        /// </summary>
        /// <param name="root"></param>
        public new void UpdateRoot(long root)
        {
            _RootPtr = root;
            _PrimFront.UpdateRoot(root);
            _PrimBack.UpdateRoot(root);
        }

        /// <summary>
        /// Helper function to read the data for this node
        /// </summary>
        /// <param name="reader">BinaryReader</param>
        /// <remarks>Binary Reader must be open and at the correct position</remarks>
        public new int FillNode(BinaryReader reader)
        {
            // Read the local Data
            _PrimPtrFront = reader.ReadInt32();
            _PrimPtrBack = reader.ReadInt32();

            // Get the Prims
            long returnaddress = reader.BaseStream.Position;
            reader.BaseStream.Position = _PrimPtrFront + _RootPtr;
            _PrimFront = LoadPrim(reader.BaseStream);
            reader.BaseStream.Position = _PrimPtrBack + _RootPtr;
            _PrimBack = LoadPrim(reader.BaseStream);

            _Size += (8 + _PrimFront.Size + _PrimBack.Size);
            return 1;
        }

        /// <summary>
        /// Updates Sizes and Pointers for the Node and SubTree Nodes 
        /// </summary>
        private void UpdatePointers()
        {
            _PrimPtrFront = _NodePtr + 16;            
            _PrimPtrBack = _PrimPtrFront + _PrimFront.Size;            
        }
        #endregion
    }

    /// <summary>
    /// Culled Primitive Node.
    /// Inherits BNode.
    /// </summary>
    [Guid("20325482-BD37-44AC-AC15-DDE64F0B4D68")]
    public class BCulledPrimitiveNode : BNode, IBSPNode
    {
        #region Properties
        /// <summary>
        /// Read-Only type of Polygon this Primitive Node contains.
        /// </summary>
        public PolyType PolygonType
        { get { return _Prim.PolygonType; } }
        /// <summary>
        /// The F4BMS.Poly object this Node contains.
        /// </summary>
        public IPrimitive Primitive
        {
            get { return _Prim; }
            set { _Prim = value; }
        }
        /// <summary>
        /// The offset of this Node relative to the Root Node.
        /// </summary>
        public new long NodeAddress
        {
            get { return _NodePtr; }
            set
            {
                _NodePtr = value;
            }
        }
        #endregion

        #region Fields
        long _PrimPtr;
        IPrimitive _Prim;
        #endregion

        #region Constructors
        /// <summary>
        /// Returns an uninitialized object of type <see cref="BCulledPrimitiveNode"/>.
        /// </summary>
        public BCulledPrimitiveNode() : base()
        {
            _NodeType = NodeType.CulledPrimitiveNode;
            _VFT = (int)_NodeType;
            _Prim = null;
            _Size += 4;
        }

        /// <summary>
        /// Returns an object of type <see cref="BCulledPrimitiveNode"/>.
        /// </summary>
        /// <remarks>This Constructor should be used when reading from a LOD File.</remarks>
        /// <param name="stream"><see cref="Stream"/>;  Must be open and at the correct stream position prior to calling this function.</param>
        /// <param name="root">The file offset of the Root Node.</param>
        public BCulledPrimitiveNode(Stream stream, long root) : base(stream, root)
        {            
            _NodeType = NodeType.CulledPrimitiveNode;
            _VFT = (int)_NodeType;
            // Fill the node
            try
            {
                using (BinaryReader reader = new BinaryReader(stream, System.Text.Encoding.Default, true))
                {
                    FillNode(reader); 
                }
            }
            catch (Exception ex)
            {

                throw new Exception("There was an error reading the Culled Primitive Node at " + _NodePtr + "\r\n" + ex.Message, ex);
            }
        }
        #endregion

        #region Methods       
        /// <summary>
        /// Print the properties for this Node in a multi-line format
        /// </summary>
        /// <returns>
        /// Multi-Line <see cref="string"/> with a new line character at the end.
        /// </returns> 
        public new string Print()
        {
            string retText = base.Print() + "\r\n";
            retText += _Prim.Print();
            return retText;
        }

        /// <summary>
        /// Debug Printing contains more data than the normal Print function.
        /// </summary>
        /// <returns>Multi-Line <see cref="string"/> with a new line at the end.</returns> 
        public new string DebugPrint()
        {
            string retText = base.DebugPrint();
            retText += "******** Culled Primitive Node Data ********\r\n";
            retText += "(" + _lineCount + ") Primitive Pointer: " + _PrimPtr + " (" + (_RootPtr + _PrimPtr) + ")\r\n"; _lineCount += 4;
            retText += _Prim.DebugPrint();
            return retText;
        }
        
        /// <summary>
        /// Writes the <c>BSPNode</c> Data to the <see cref="Stream"/>.
        /// </summary>
        /// <returns><see cref="bool"/> <c>true</c> if successful or <c>false</c> if unsuccessful.</returns>
        /// <param name="stream"><see cref="Stream"/> Must be open and at the correct position prior to calling this function.</param>
        public new bool Save(Stream stream)
        {
            _NodePtr = stream.Position - _RootPtr;;
            UpdatePointers();
            base.Save(stream);
            try
            {
                using (BinaryWriter writer = new BinaryWriter(stream, System.Text.Encoding.Default, true))
                {
                    writer.Write((int)_PrimPtr);
                    _Prim.Save(writer.BaseStream);
                }
            }
            catch
            {
                throw new Exception("There was an error while writing the Primitive Node at " + _NodePtr);
            }
            _lastNode = _NodePtr;
            return true;
        }

        /// <summary>
        /// Updates the Root Pointer for the Node to reference.
        /// </summary>
        /// <param name="root"></param>
        public new void UpdateRoot(long root)
        {
            _RootPtr = root;
            _Prim.UpdateRoot(root);
        }

        /// <summary>
        /// Helper function to read the data for this node
        /// </summary>
        /// <param name="reader">BinaryReader</param>
        /// <remarks>Binary Reader must be open and at the correct position</remarks>
        private new int FillNode(BinaryReader reader)
        {
            // Get the Prim Pointer
            _PrimPtr = reader.ReadInt32();

            // Get the Prim information
            reader.BaseStream.Position = _PrimPtr + _RootPtr;
            _Prim = LoadPrim(reader.BaseStream);

            _Size += 4 + _Prim.Size;
            return 1;
        }

        /// <summary>
        /// Updates Sizes and Pointers for the Node and SubTree Nodes 
        /// </summary>
        private void UpdatePointers()
        {
            _PrimPtr = _NodePtr + 12;
            _Prim.PrimitiveAddress = _PrimPtr;
        }
        #endregion
    }

    /// <summary>
    /// SpecialXForm Node.
    /// Inherits BNode.
    /// </summary>
    [Guid("576BB2EC-1A08-48BE-B213-65CE0AEC7047")]
    public class BSpecialXFormNode : BNode, IBSPNode
    {
        #region Properties
        /// <summary>
        /// Collection of <see cref="System.Windows.Media.Media3D.Point3D"/> objects to represent the 3D Transform Coordinates.
        /// </summary>
        public List<System.Windows.Media.Media3D.Point3D> Coordinates
        {
            get { return _Coords; }
            set { _Coords = value;
                _nCoords = _Coords.Count;
            }
        }
        /// <summary>
        /// Read-Only count of the number of Transform Coordinates.
        /// </summary>
        public int CoordinateCount
        { get { return _nCoords; } }
        /// <summary>
        /// The File Offset of the Coordinates relative to the Root Node.
        /// </summary>
        public long CoordinatePointer
        {
            get { return _CoordsPtr; }
            set { _CoordsPtr = value; }
        }
        /// <summary>
        /// The type of Transform this Node performs.
        /// </summary>
        public TransformType TransformType
        {
            get { return _XFormType; }
            set { _XFormType = value; }
        }
        /// <summary>
        /// The File Offset relative to the Root Node where the SubTree exists.  The Node at this location will be processed after the current node.
        /// </summary>
        public long SubTreePointer
        {
            get { return _SubTreePointer; }
            set { _SubTreePointer = value; }
        }
        /// <summary>
        /// Collection of the Nodes which make up this SpecialTransform.
        /// </summary>
        public List<IBSPNode> SubTree
        {
            get { return _SubTree; }
            set { _SubTree = value;
            }
        }
        /// <summary>
        /// The Total Size of the Node including all extra data and SubTrees.
        /// </summary>
        public new int TotalSize
        {
            get
            {
                int size = _Size;
                foreach (IBSPNode node in _SubTree)
                    size += node.TotalSize;
                return size;
            }
        }
        /// <summary>
        /// Read-Only Count of the Number of <c>BSPNode</c> objects this Node represents including SubTrees.
        /// </summary>
        public new int NodeCount
        {
            get
            {
                int count = 1;
                foreach (IBSPNode node in _SubTree)
                    count += node.NodeCount;
                return count;
            }
        }
        /// <summary>
        /// The offset of this Node relative to the Root Node.
        /// </summary>
        public new long NodeAddress
        {
            get { return _NodePtr; }
            set
            {
                _NodePtr = value;
            }
        }
        #endregion

        #region Fields
        private long _CoordsPtr;
        private int _nCoords;
        private TransformType _XFormType;
        private long _SubTreePointer;
        private List<System.Windows.Media.Media3D.Point3D> _Coords;
        private List<IBSPNode> _SubTree;
        #endregion

        #region Constructors
        /// <summary>
        /// Returns an uninitialized object of type <see cref="BSpecialXFormNode"/>.
        /// </summary>
        public BSpecialXFormNode() : base()
        {
            _NodeType = NodeType.SpecialXFormNode;
            _VFT = (int)_NodeType;
            _CoordsPtr = 0;
            _nCoords = 0;
            _XFormType = TransformType.Normal;
            _SubTreePointer = 0;
            _Coords = new List<System.Windows.Media.Media3D.Point3D>();
            _SubTree = new List<IBSPNode>();

            _Size += 16;
        }

        /// <summary>
        /// Returns an object of type <see cref="BSpecialXFormNode"/>.
        /// </summary>
        /// <remarks>This Constructor should be used when reading from a LOD File.</remarks>
        /// <param name="stream"><see cref="Stream"/>;  Must be open and at the correct stream position prior to calling this function.</param>
        /// <param name="root">The file offset of the Root Node.</param>
        public BSpecialXFormNode(Stream stream, long root) : base(stream, root)
        {
            
            // Load the data
            _NodeType = NodeType.SpecialXFormNode;
            _VFT = (int)_NodeType;
            try
            {
                using (BinaryReader reader = new BinaryReader(stream, System.Text.Encoding.Default, true))
                {
                    _CoordsPtr = reader.ReadInt32();
                    _nCoords = reader.ReadInt32();
                    _XFormType = (TransformType)reader.ReadInt32();
                    _SubTreePointer = reader.ReadInt32();
                    _Coords = new List<System.Windows.Media.Media3D.Point3D>();
                    _SubTree = new List<IBSPNode>();

                    // Get the Coords
                    if (_nCoords > 0)
                    {
                        long returnaddress = reader.BaseStream.Position;
                        reader.BaseStream.Position = _CoordsPtr + _RootPtr;
                        for (int i = 0; i < _nCoords; i++)
                        {
                            _Coords.Add(new System.Windows.Media.Media3D.Point3D(reader.ReadSingle(), reader.ReadSingle(), reader.ReadSingle()));
                        }
                        reader.BaseStream.Position = returnaddress;
                    }
                }
            }
            catch (Exception ex)
            {

                throw new Exception("There was an error while reading the Special Transform Node at " + _NodePtr + "\r\n" + ex.Message, ex);
            }         
            _Size += (16 + (12 * _nCoords));


        }
        #endregion

        #region Methods
        /// <summary>
        /// Print the properties for this Node in a multi-line format
        /// </summary>
        /// <returns>
        /// Multi-Line <see cref="string"/> with a new line character at the end.
        /// </returns> 
        public new string Print()
        {
            string retText = base.Print();
            retText += "Transform Type: " + TransformType + "\r\n";
            retText += "SubTree Pointer: " + _SubTreePointer + "\r\n";
            retText += "Number of Coords: " + _nCoords + "\r\n";
            for (int i = 0; i < _nCoords; i++)
                retText += "    (" + _Coords[i].X + ", " + _Coords[i].Y + ", " + _Coords[i].Z + ")\r\n";
            foreach (IBSPNode node in _SubTree)
                retText += node.Print();
            return retText;
        }

        /// <summary>
        /// Debug Printing contains more data than the normal Print function.
        /// </summary>
        /// <returns>Multi-Line <see cref="string"/> with a new line at the end.</returns> 
        public new string DebugPrint()
        {
            string retText = base.Print();
            retText += "******** SpecialXForm Node Data ********\r\n";
            retText += "(" + _lineCount + ") Coords Pointer: " + _CoordsPtr + " (" + (_RootPtr + _CoordsPtr) + ")\r\n"; _lineCount += 4;
            retText += "(" + _lineCount + ") Number of Coords: " + _nCoords + "\r\n"; _lineCount += 4;
            retText += "(" + _lineCount + ") Transform Type: " + TransformType + "\r\n"; _lineCount += 4;
            retText += "(" + _lineCount + ") SubTree Pointer: " + _SubTreePointer + " (" + (_RootPtr + _SubTreePointer) + ")\r\n"; _lineCount += 4;
            foreach (IBSPNode node in _SubTree)
                retText += node.DebugPrint();
            retText += "Coords: \r\n";
            for (int i = 0; i < _nCoords; i++)
                retText += "(" + (_RootPtr + _CoordsPtr + (12 * i)) + ")     (" + _Coords[i].X + ", " + _Coords[i].Y + ", " + _Coords[i].Z + ")\r\n";
            return retText;
        }

        /// <summary>
        /// Writes the <c>BSPNode</c> Data to the <see cref="Stream"/>.
        /// </summary>
        /// <returns><see cref="bool"/> <c>true</c> if successful or <c>false</c> if unsuccessful.</returns>
        /// <param name="stream"><see cref="Stream"/> Must be open and at the correct position prior to calling this function.</param>
        public new bool Save(Stream stream)
        {
            _NodePtr = stream.Position - _RootPtr;
            UpdatePointers();
            // Write the VFT and Sibling data
            base.Save(stream);
            // Write the SpecialNode Data            
            try
            {
                using (BinaryWriter writer = new BinaryWriter(stream, System.Text.Encoding.Default, true))
                {
                    // Write the generic node data to the stream
                    writer.Write((int)_CoordsPtr);
                    writer.Write(_nCoords);
                    writer.Write((int)_XFormType);
                    writer.Write((int)_SubTreePointer);

                    // Recursive call to write the data for the subtree nodes
                    _lastNode = -1;   
                    for (int i = _SubTree.Count - 1; i >= 0; i--)
                        _SubTree[i].Save(stream);

                    // Write the extra data for the subtree if it exists
                    foreach (System.Windows.Media.Media3D.Point3D p in _Coords)
                    {
                        writer.Write((Single)p.X);
                        writer.Write((Single)p.Y);
                        writer.Write((Single)p.Z);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("There was an error while writing the SpecialXForm Node at " + _NodePtr + "\r\n" + ex.Message, ex);
            }
            _lastNode = _NodePtr;
            return true;
        }

        /// <summary>
        /// Returns a list of the Node Types for this Node and any SubTree Nodes.
        /// </summary>
        /// <returns></returns>
        public new List<int> GetNodeTypes()
        {
            List<int> nodetypes = new List<int>
            {
                (int)_NodeType
            };
            foreach (IBSPNode node in _SubTree)
                nodetypes.AddRange(node.GetNodeTypes());
            return nodetypes;
        }

        /// <summary>
        /// Updates the Root Pointer for the Node to reference.
        /// </summary>
        /// <param name="root"></param>
        public new void UpdateRoot(long root)
        {
            _RootPtr = root;
            foreach (IBSPNode node in _SubTree)
                node.UpdateRoot(root);       
        }

        /// <summary>
        /// Updates Sizes and Pointers for the Node and SubTree Nodes 
        /// </summary>
        private void UpdatePointers()
        {
            //Get the size of the Tree
            int _TreeSize = 0;
            foreach (IBSPNode node in _SubTree)
                _TreeSize += node.TotalSize;
            // Pointers need to be set to an offset from the RootNode            
            _CoordsPtr = _NodePtr + 24 + _TreeSize;
            // The remaining Ptrs can be offset from Coords
            if (SubTree.Count > 0)
                _SubTreePointer = _NodePtr + 24 + (_TreeSize - (SubTree[0].TotalSize));
            else
                _SubTreePointer = -1;
           
        }
        #endregion
    }

    /// <summary>
    /// Light String Node.
    /// Inherits PrimitiveNode.
    /// </summary>
    [Guid("44D17600-2762-46F3-AE61-962BD6A69479")]
    public class BLightStringNode : BPrimitiveNode, IBSPNode
    {
        #region Properties
        /// <summary>
        /// LightStringNode A Component.  Normal I Component.
        /// </summary>
        public float A
        {
            get { return _A; }
            set { _A = value; }
        }
        /// <summary>
        /// LightStringNode B Component.  Normal J Component.
        /// </summary>
        public float B
        {
            get { return _B; }
            set { _B = value; }
        }
        /// <summary>
        /// LightStringNode C Component.  Normal K Component.
        /// </summary>
        public float C
        {
            get { return _C; }
            set { _C = value; }
        }
        /// <summary>
        /// LightStringNode D Component.  Light Intensity Component.
        /// </summary>
        public float D
        {
            get { return _D; }
            set { _D = value; }
        }
        /// <summary>
        /// The color index of the Front Primitive color.
        /// </summary>
        public int FrontRGBA
        {
            get { return _RGBAFront; }
            set { _RGBAFront = value; }
        }
        /// <summary>
        /// The color index of the Back Primitive color.
        /// </summary>
        public int BackRGBA
        {
            get { return _RGBABack; }
            set { _RGBABack = value; }
        }
        /// <summary>
        /// The offset of this Node relative to the Root Node.
        /// </summary>
        public new long NodeAddress
        {
            get { return _NodePtr; }
            set
            {
                _NodePtr = value;
            }
        }
        #endregion

        #region Fields
        private float _A;
        private float _B;
        private float _C;
        private float _D;
        private int _RGBAFront;
        private int _RGBABack;
        #endregion

        #region Constructors
        /// <summary>
        /// Returns an uninitialized object of type <see cref="BLightStringNode"/>.
        /// </summary>
        public BLightStringNode() : base()
        {
            _A = _B = _C = _D = 0;
            _RGBAFront = _RGBABack = 0;
            _NodeType = NodeType.LightStringNode;
            _VFT = (int)_NodeType;
            _Size += 24;
        }

        /// <summary>
        /// Returns an object of type <see cref="BLightStringNode"/>.
        /// </summary>
        /// <remarks>This Constructor should be used when reading from a LOD File.</remarks>
        /// <param name="stream"><see cref="Stream"/>;  Must be open and at the correct stream position prior to calling this function.</param>
        /// <param name="root">The file offset of the Root Node.</param>
        public BLightStringNode(Stream stream, long root) : base(stream, root)
        {

            try
            {
                using (BinaryReader reader = new BinaryReader(stream, System.Text.Encoding.Default, true))
                {
                    _A = reader.ReadInt32();
                    _B = reader.ReadInt32();
                    _C = reader.ReadInt32();
                    _D = reader.ReadInt32();
                    _RGBAFront = reader.ReadInt32();
                    _RGBABack = reader.ReadInt32();
                }
            }
            catch (Exception ex)
            {

                throw new Exception("There was an error reading the Light String Node at " + _NodePtr + "\r\n" + ex.Message, ex);
            }
            _NodeType = NodeType.LightStringNode;
            _VFT = (int)_NodeType;
            _Size += 24;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Print the properties for this Node in a multi-line format
        /// </summary>
        /// <returns>
        /// Multi-Line <see cref="string"/> with a new line character at the end.
        /// </returns> 
        public new string Print()
        {
            string retText = base.Print();
            retText += "A: " + _A + "\r\n";
            retText += "B: " + _B + "\r\n";
            retText += "C: " + _C + "\r\n";
            retText += "D: " + _D + "\r\n";
            retText += "Front RGBA: " + _RGBAFront + "\r\n";
            retText += "Back RGBA: " + _RGBABack + "\r\n";
            return retText;
        }

        /// <summary>
        /// Debug Printing contains more data than the normal Print function.
        /// </summary>
        /// <returns>Multi-Line <see cref="string"/> with a new line at the end.</returns> 
        public new string DebugPrint()
        {
            string retText = base.DebugPrint();
            retText += "******** LightString Node Data ********\r\n";
            retText += "(" + _lineCount + ") A: " + _A + "\r\n"; _lineCount += 4;
            retText += "(" + _lineCount + ") B: " + _B + "\r\n"; _lineCount += 4;
            retText += "(" + _lineCount + ") C: " + _C + "\r\n"; _lineCount += 4;
            retText += "(" + _lineCount + ") D: " + _D + "\r\n"; _lineCount += 4;
            retText += "(" + _lineCount + ") Front RGBA: " + _RGBAFront + "\r\n"; _lineCount += 4;
            retText += "(" + _lineCount + ") Back RGBA: " + _RGBABack + "\r\n"; _lineCount += 4;
            return retText;
        }

        /// <summary>
        /// Writes the <c>BSPNode</c> Data to the <see cref="Stream"/>.
        /// </summary>
        /// <returns><see cref="bool"/> <c>true</c> if successful or <c>false</c> if unsuccessful.</returns>
        /// <param name="stream"><see cref="Stream"/> Must be open and at the correct position prior to calling this function.</param>
        public new bool Save(Stream stream)
        {
            _NodePtr = stream.Position - _RootPtr;;
            UpdatePointers();
            base.Save(stream);
            try
            {
                using (BinaryWriter writer = new BinaryWriter(stream, System.Text.Encoding.Default, true))
                {
                    writer.Write(_A);
                    writer.Write(_B);
                    writer.Write(_C);
                    writer.Write(_D);
                    writer.Write(_RGBAFront);
                    writer.Write(_RGBABack);
                    _Prim.Save(writer.BaseStream);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("There was an error while writing the Light String Node at " + _NodePtr + "\r\n" + ex.Message, ex);
            }
            _lastNode = _NodePtr;
            return true;
        }

        /// <summary>
        /// Updates Sizes and Pointers for the Node and SubTree Nodes 
        /// </summary>
        private void UpdatePointers()
        {
            _PrimPtr = _NodePtr + 36;
            _Prim.PrimitiveAddress = _PrimPtr;
        }
        #endregion
    }

    /// <summary>
    /// TransNode.  Inherits BNode.
    /// </summary>
    [Guid("3F2DFDD7-F44E-430A-A04C-A28D35A25BD8")]
    public class BTransNode : BSubTreeNode, IBSPNode
    {
        #region Properties
        /// <summary>
        /// The DOF Number associate with this Transposition
        /// </summary>
        public DOFID DOFID
        {
            get { return (DOFID)_DOFID; }
            set { _DOFID = (int)value; }
        }
        /// <summary>
        /// The minimum scaling which can be applied to this DOF node.
        /// </summary>
        public float Min
        {
            get { return _Min; }
            set { _Min = value; }
        }
        /// <summary>
        /// The maximum scaling which can be applied to this DOF node.
        /// </summary>
        public float Max
        {
            get { return _Max; }
            set { _Max = value; }
        }
        /// <summary>
        /// The scaling factor to apply to this Transposition.
        /// </summary>
        public float Multiplier
        {
            get { return _Multiplier; }
            set { _Multiplier = value; }
        }
        /// <summary>
        /// The future scale factor of this Node.
        /// </summary>
        public float Future
        {
            get { return _Future; }
            set { _Future = value; }
        }
        /// <summary>
        /// Flags associated with this Node.
        /// </summary>
        public int Flags
        {
            get { return _Flags; }
            set { _Flags = value; }
        }
        /// <summary>
        /// The translation point for this DOF node.
        /// </summary>
        public System.Windows.Media.Media3D.Point3D TranslationPoint
        {
            get { return _TranslationPoint; }
            set { _TranslationPoint = value; }
        }
        /// <summary>
        /// The Total Size of the Node including all extra data and SubTrees.
        /// </summary>
        public new int TotalSize
        {
            get
            {
                return base.TotalSize;
            }
        }
        /// <summary>
        /// Read-Only Count of the Number of <c>BSPNode</c> objects this Node represents including SubTrees.
        /// </summary>
        public new int NodeCount
        {
            get
            {
                return base.NodeCount;
            }
        }
        /// <summary>
        /// The offset of this Node relative to the Root Node.
        /// </summary>
        public new long NodeAddress
        {
            get { return _NodePtr; }
            set
            {
                _NodePtr = value;
            }
        }
        #endregion

        #region Fields
        private int _DOFID;
        private float _Min;
        private float _Max;
        private float _Multiplier;
        private float _Future;
        private int _Flags;
        private System.Windows.Media.Media3D.Point3D _TranslationPoint;
        #endregion

        #region Constructors
        /// <summary>
        /// Returns an uninitialized object of type <see cref="BTransNode"/>.
        /// </summary>
        public BTransNode() : base()
        {
            _NodeType = NodeType.TransNode;
            _VFT = (int)_NodeType;
            _Size += 36;
        }

        /// <summary>
        /// Returns an object of type <see cref="BTransNode"/>.
        /// </summary>
        /// <remarks>This Constructor should be used when reading from a LOD File.</remarks>
        /// <param name="stream"><see cref="Stream"/>;  Must be open and at the correct stream position prior to calling this function.</param>
        /// <param name="root">The file offset of the Root Node.</param>
        public BTransNode(Stream stream, long root) : base(stream, root)
        {
            
            _NodeType = NodeType.TransNode;
            _VFT = (int)_NodeType;
            try
            {
                using (BinaryReader reader = new BinaryReader(stream, System.Text.Encoding.Default, true))
                {
                    _DOFID = reader.ReadInt32();
                    _Min = reader.ReadSingle();
                    _Max = reader.ReadSingle();
                    _Multiplier = reader.ReadSingle();
                    _Future = reader.ReadSingle();
                    _Flags = reader.ReadInt32();
                    _TranslationPoint = new System.Windows.Media.Media3D.Point3D(reader.ReadSingle(), reader.ReadSingle(), reader.ReadSingle());
                }
            }
            catch (Exception ex)
            {

                throw new Exception("There was an error reading the Transpose Node at " + _NodePtr + "\r\n" + ex.Message, ex);
            }
            _Size += 36;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Print the properties for this Node in a multi-line format
        /// </summary>
        /// <returns>
        /// Multi-Line <see cref="string"/> with a new line character at the end.
        /// </returns> 
        public new string Print()
        {
            string retText = base.Print();
            retText += "DOF Number: " + _DOFID + "\r\n";
            retText += "Min Scaling: " + _Min + "\r\n";
            retText += "Max Scaling: " + _Max + "\r\n";
            retText += "Scaling Factor: " + _Multiplier + "\r\n";
            retText += "Future Scaling Factor: " + _Future + "\r\n";
            retText += "Flags: " + _Flags + "\r\n";
            retText += "Translation Point: (" + _TranslationPoint.X + ", " + _TranslationPoint.Y + ", " + _TranslationPoint.Z + ")\r\n";
            return retText;
        }

        /// <summary>
        /// Debug Printing contains more data than the normal Print function.
        /// </summary>
        /// <returns>Multi-Line <see cref="string"/> with a new line at the end.</returns> 
        public new string DebugPrint()
        {
            string retText = base.DebugPrint();
            retText += "******** Trans Node Data ********\r\n";
            retText += "(" + _lineCount + ") DOF Number: " + _DOFID + "\r\n"; _lineCount += 4;
            retText += "(" + _lineCount + ") Min Scaling: " + _Min + "\r\n"; _lineCount += 4;
            retText += "(" + _lineCount + ") Max Scaling: " + _Max + "\r\n"; _lineCount += 4;
            retText += "(" + _lineCount + ") Scaling Factor: " + _Multiplier + "\r\n"; _lineCount += 4;
            retText += "(" + _lineCount + ") Future Scaling Factor: " + _Future + "\r\n"; _lineCount += 4;
            retText += "(" + _lineCount + ") Flags: " + _Flags + "\r\n"; _lineCount += 4;
            retText += "(" + _lineCount + ") Translation Point: (" + _TranslationPoint.X + ", " + _TranslationPoint.Y + ", " + _TranslationPoint.Z + ")\r\n"; _lineCount += 12;
            return retText;
        }

        /// <summary>
        /// Returns a list of the Node Types for this Node and any SubTree Nodes.
        /// </summary>
        /// <returns></returns>
        public new List<int> GetNodeTypes()
        {
            return base.GetNodeTypes();
        }

        /// <summary>
        /// Writes the <c>BSPNode</c> Data to the <see cref="Stream"/>.
        /// </summary>
        /// <returns><see cref="bool"/> <c>true</c> if successful or <c>false</c> if unsuccessful.</returns>
        /// <param name="stream"><see cref="Stream"/> Must be open and at the correct position prior to calling this function.</param>
        public new bool Save(Stream stream)
        {
            base.Save(stream);
            return true;
        }
        #endregion
    }

    /// <summary>
    /// ScaleNode.  Inherits SubTreeNode.
    /// </summary>
    [Guid("C95405F9-5CFF-4D9E-831C-C4A62377CB90")]
    public class BScaleNode : BSubTreeNode, IBSPNode
    {
        #region Properties
        /// <summary>
        /// The DOF Number associate with this Transposition
        /// </summary>
        public DOFID DOFID
        {
            get { return (DOFID)_DOFID; }
            set { _DOFID = (int)value; }
        }
        /// <summary>
        /// The minimum scaling which can be applied to this DOF node.
        /// </summary>
        public float Min
        {
            get { return _Min; }
            set { _Min = value; }
        }
        /// <summary>
        /// The maximum scaling which can be applied to this DOF node.
        /// </summary>
        public float Max
        {
            get { return _Max; }
            set { _Max = value; }
        }
        /// <summary>
        /// The scaling factor to apply to this Transposition.
        /// </summary>
        public float Multiplier
        {
            get { return _Multiplier; }
            set { _Multiplier = value; }
        }
        /// <summary>
        /// The future scale factor of this Node.
        /// </summary>
        public float Future
        {
            get { return _Future; }
            set { _Future = value; }
        }
        /// <summary>
        /// Flags associated with this Node.
        /// </summary>
        public int Flags
        {
            get { return _Flags; }
            set { _Flags = value; }
        }
        /// <summary>
        /// The Scale point for this DOF node.
        /// </summary>
        public System.Windows.Media.Media3D.Point3D ScalePoint
        {
            get { return _ScalePoint; }
            set { _ScalePoint = value; }
        }
        /// <summary>
        /// The Transposition point for this DOF node.
        /// </summary>
        public System.Windows.Media.Media3D.Point3D TranslationPoint
        {
            get { return _TranslationPoint; }
            set { _TranslationPoint = value; }
        }
        /// <summary>
        /// The Total Size of the Node including all extra data and SubTrees.
        /// </summary>
        public new int TotalSize
        {
            get
            {
                return base.TotalSize;
            }
        }
        /// <summary>
        /// Read-Only Count of the Number of <c>BSPNode</c> objects this Node represents including SubTrees.
        /// </summary>
        public new int NodeCount
        {
            get
            {
                return base.NodeCount;
            }
        }
        /// <summary>
        /// The offset of this Node relative to the Root Node.
        /// </summary>
        public new long NodeAddress
        {
            get { return _NodePtr; }
            set
            {
                _NodePtr = value;
            }
        }
        #endregion

        #region Fields
        private int _DOFID;
        private float _Min;
        private float _Max;
        private float _Multiplier;
        private float _Future;
        private int _Flags;
        private System.Windows.Media.Media3D.Point3D _ScalePoint;
        private System.Windows.Media.Media3D.Point3D _TranslationPoint;
        #endregion
        
        #region Constructors
        /// <summary>
        /// Returns an uninitialized object of type <see cref="BTransNode"/>.
        /// </summary>
        public BScaleNode() : base()
        {
            _NodeType = NodeType.ScaleNode;
            _VFT = (int)_NodeType;
            _Size += 48;
        }

        /// <summary>
        /// Returns an object of type <see cref="BTransNode"/>.
        /// </summary>
        /// <remarks>This Constructor should be used when reading from a LOD File.</remarks>
        /// <param name="stream"><see cref="Stream"/>;  Must be open and at the correct stream position prior to calling this function.</param>
        /// <param name="root">The file offset of the Root Node.</param>
        public BScaleNode(Stream stream, long root) : base(stream, root)
        {
            
            _NodeType = NodeType.ScaleNode;
            _VFT = (int)_NodeType;
            try
            {
                using (BinaryReader reader = new BinaryReader(stream, System.Text.Encoding.Default, true))
                {
                    _DOFID = reader.ReadInt32();
                    _Min = reader.ReadSingle();
                    _Max = reader.ReadSingle();
                    _Multiplier = reader.ReadSingle();
                    _Future = reader.ReadSingle();
                    _Flags = reader.ReadInt32();
                    _ScalePoint = new System.Windows.Media.Media3D.Point3D(reader.ReadSingle(), reader.ReadSingle(), reader.ReadSingle());
                    _TranslationPoint = new System.Windows.Media.Media3D.Point3D(reader.ReadSingle(), reader.ReadSingle(), reader.ReadSingle());
                }
            }
            catch (Exception ex)
            {

                throw new Exception("There was an error reading the Scale Node at " + _NodePtr + "\r\n" + ex.Message, ex);
            }
            _Size += 48;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Print the properties for this Node in a multi-line format
        /// </summary>
        /// <returns>
        /// Multi-Line <see cref="string"/> with a new line character at the end.
        /// </returns> 
        public new string Print()
        {
            string retText = base.Print();
            retText += "DOF Number: " + _DOFID + "\r\n";
            retText += "Min Scaling: " + _Min + "\r\n";
            retText += "Max Scaling: " + _Max + "\r\n";
            retText += "Scaling Factor: " + _Multiplier + "\r\n";
            retText += "Future Scaling Factor: " + _Future + "\r\n";
            retText += "Flags: " + _Flags + "\r\n";
            retText += "Scale Point: (" + _ScalePoint.X + ", " + _ScalePoint.Y + ", " + _ScalePoint.Z + ")\r\n";
            retText += "Translation Point: (" + _TranslationPoint.X + ", " + _TranslationPoint.Y + ", " + _TranslationPoint.Z + ")\r\n";
            return retText;
        }

        /// <summary>
        /// Debug Printing contains more data than the normal Print function.
        /// </summary>
        /// <returns>Multi-Line <see cref="string"/> with a new line at the end.</returns> 
        public new string DebugPrint()
        {
            string retText = base.DebugPrint();
            retText += "******** Scale Node Data ********\r\n";
            retText += "(" + _lineCount + ") DOF Number: " + _DOFID + "\r\n"; _lineCount += 4;
            retText += "(" + _lineCount + ") Min Scaling: " + _Min + "\r\n"; _lineCount += 4;
            retText += "(" + _lineCount + ") Max Scaling: " + _Max + "\r\n"; _lineCount += 4;
            retText += "(" + _lineCount + ") Scaling Factor: " + _Multiplier + "\r\n"; _lineCount += 4;
            retText += "(" + _lineCount + ") Future Scaling Factor: " + _Future + "\r\n"; _lineCount += 4;
            retText += "(" + _lineCount + ") Flags: " + _Flags + "\r\n"; _lineCount += 4;
            retText += "(" + _lineCount + ") Scale Point: (" + _ScalePoint.X + ", " + _ScalePoint.Y + ", " + _ScalePoint.Z + ")\r\n"; _lineCount += 12;
            retText += "(" + _lineCount + ") Translation Point: (" + _TranslationPoint.X + ", " + _TranslationPoint.Y + ", " + _TranslationPoint.Z + ")\r\n"; _lineCount += 12;
            return retText;
        }

        /// <summary>
        /// Returns a list of the Node Types for this Node and any SubTree Nodes.
        /// </summary>
        /// <returns></returns>
        public new List<int> GetNodeTypes()
        {
            return base.GetNodeTypes();
        }

        /// <summary>
        /// Writes the <c>BSPNode</c> Data to the <see cref="Stream"/>.
        /// </summary>
        /// <returns><see cref="bool"/> <c>true</c> if successful or <c>false</c> if unsuccessful.</returns>
        /// <param name="stream"><see cref="Stream"/> Must be open and at the correct position prior to calling this function.</param>
        public new bool Save(Stream stream)
        {
            base.Save(stream);
            return true;
        }
        #endregion
    }

    /// <summary>
    /// XDOFNode.  Inherits SubTree.
    /// </summary>
    [Guid("F481FE67-9090-4FFD-8DFE-66D8EA544764")]
    public class BXDofNode : BSubTreeNode, IBSPNode
    {
        #region Properties
        /// <summary>
        /// The DOF Number associate with this Transposition
        /// </summary>
        public DOFID DOFID
        {
            get { return (DOFID)_DOFID; }
            set { _DOFID = (int)value; }
        }
        /// <summary>
        /// The minimum scaling which can be applied to this DOF node.
        /// </summary>
        public float Min
        {
            get { return _Min; }
            set { _Min = value; }
        }
        /// <summary>
        /// The maximum scaling which can be applied to this DOF node.
        /// </summary>
        public float Max
        {
            get { return _Max; }
            set { _Max = value; }
        }
        /// <summary>
        /// The scaling factor to apply to this Transposition.
        /// </summary>
        public float Multiplier
        {
            get { return _Multiplier; }
            set { _Multiplier = value; }
        }
        /// <summary>
        /// The future scale factor of this Node.
        /// </summary>
        public float Future
        {
            get { return _Future; }
            set { _Future = value; }
        }
        /// <summary>
        /// Flags associated with this Node.
        /// </summary>
        public int Flags
        {
            get { return _Flags; }
            set { _Flags = value; }
        }
        /// <summary>
        /// 3x3 Matrix of Floats to represent the rotation matrix.
        /// </summary>
        public float[,] RotationMatrix
        {
            get { return _RotationMatrix; }
            set { _RotationMatrix = value; }
        }
        /// <summary>
        /// The Transposition point for this DOF node.
        /// </summary>
        public System.Windows.Media.Media3D.Point3D TranslationPoint
        {
            get { return _TranslationPoint; }
            set { _TranslationPoint = value; }
        }
        /// <summary>
        /// The Total Size of the Node including all extra data and SubTrees.
        /// </summary>
        public new int TotalSize
        {
            get
            {
                return base.TotalSize;
            }
        }
        /// <summary>
        /// Read-Only Count of the Number of <c>BSPNode</c> objects this Node represents including SubTrees.
        /// </summary>
        public new int NodeCount
        {
            get
            {
                return base.NodeCount;
            }
        }
        #endregion

        #region Fields
        private int _DOFID;
        private float _Min;
        private float _Max;
        private float _Multiplier;
        private float _Future;
        private int _Flags;
        private float[,] _RotationMatrix;
        private System.Windows.Media.Media3D.Point3D _TranslationPoint;
        #endregion

        #region Constructors
        /// <summary>
        /// Returns an uninitialized object of type <see cref="BXDofNode"/>.
        /// </summary>
        public BXDofNode() : base()
        {
            _NodeType = NodeType.XDOFNode;
            _VFT = (int)_NodeType;
            _RotationMatrix = new float[3, 3];
            _Size += 72;
        }

        /// <summary>
        /// Returns an object of type <see cref="BXDofNode"/>.
        /// </summary>
        /// <remarks>This Constructor should be used when reading from a LOD File.</remarks>
        /// <param name="stream"><see cref="Stream"/>;  Must be open and at the correct stream position prior to calling this function.</param>
        /// <param name="root">The file offset of the Root Node.</param>
        public BXDofNode(Stream stream, long root) : base(stream, root)
        {
            
            _NodeType = NodeType.XDOFNode;
            _VFT = (int)_NodeType;
            _RotationMatrix = new float[3, 3];
            try
            {
                using (BinaryReader reader = new BinaryReader(stream, System.Text.Encoding.Default, true))
                {
                    _DOFID = reader.ReadInt32();
                    _Min = reader.ReadSingle();
                    _Max = reader.ReadSingle();
                    _Multiplier = reader.ReadSingle();
                    _Future = reader.ReadSingle();
                    _Flags = reader.ReadInt32();
                    for (int i = 0; i < 3; i++)
                    {
                        for (int j = 0; j < 3; j++)
                        {
                            _RotationMatrix[i, j] = reader.ReadSingle();
                        }
                    }
                    _TranslationPoint = new System.Windows.Media.Media3D.Point3D(reader.ReadSingle(), reader.ReadSingle(), reader.ReadSingle());
                }
            }
            catch (Exception ex)
            {

                throw new Exception("There was an error reading the XDOF Node at " + _NodePtr + "\r\n" + ex.Message, ex);
            }
            _Size += 72;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Print the properties for this Node in a multi-line format
        /// </summary>
        /// <returns>
        /// Multi-Line <see cref="string"/> with a new line character at the end.
        /// </returns> 
        public new string Print()
        {
            string retText = base.Print();
            retText += "DOF Number: " + _DOFID + "\r\n";
            retText += "Min Scaling: " + _Min + "\r\n";
            retText += "Max Scaling: " + _Max + "\r\n";
            retText += "Scaling Factor: " + _Multiplier + "\r\n";
            retText += "Future Scaling Factor: " + _Future + "\r\n";
            retText += "Flags: " + _Flags + "\r\n";
            retText += "Rotation MAtrix: \r\n";
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    retText += _RotationMatrix[i, j] + "  ";
                }
                retText += "\r\n";
            }
            retText += "Translation Point: (" + _TranslationPoint.X + ", " + _TranslationPoint.Y + ", " + _TranslationPoint.Z + ")\r\n";
            return retText;
        }

        /// <summary>
        /// Debug Printing contains more data than the normal Print function.
        /// </summary>
        /// <returns>Multi-Line <see cref="string"/> with a new line at the end.</returns> 
        public new string DebugPrint()
        {
            string retText = base.DebugPrint();
            retText += "******** XDOF Node Data ********\r\n";
            retText += "(" + _lineCount + ") DOF Number: " + _DOFID + "\r\n"; _lineCount += 4;
            retText += "(" + _lineCount + ") Min Scaling: " + _Min + "\r\n"; _lineCount += 4;
            retText += "(" + _lineCount + ") Max Scaling: " + _Max + "\r\n"; _lineCount += 4;
            retText += "(" + _lineCount + ") Scaling Factor: " + _Multiplier + "\r\n"; _lineCount += 4;
            retText += "(" + _lineCount + ") Future Scaling Factor: " + _Future + "\r\n"; _lineCount += 4;
            retText += "(" + _lineCount + ") Flags: " + _Flags + "\r\nRotation MAtrix:\r\n"; _lineCount += 4;
            for (int i = 0; i < 3; i++)
            {
                retText += "(" + _lineCount + ")";
                for (int j = 0; j < 3; j++)
                {
                    retText += _RotationMatrix[i, j] + "  "; _lineCount += 4;
                }
                retText += "\r\n";
            }
            retText += "(" + _lineCount + ") Translation Point: (" + _TranslationPoint.X + ", " + _TranslationPoint.Y + ", " + _TranslationPoint.Z + ")\r\n"; _lineCount += 12;
            return retText;
        }

        /// <summary>
        /// Writes the <c>BSPNode</c> Data to the <see cref="Stream"/>.
        /// </summary>
        /// <returns><see cref="bool"/> <c>true</c> if successful or <c>false</c> if unsuccessful.</returns>
        /// <param name="stream"><see cref="Stream"/> Must be open and at the correct position prior to calling this function.</param>
        public new bool Save(Stream stream)
        {
            base.Save(stream);
            return true;
        }

        /// <summary>
        /// Returns a list of the Node Types for this Node and any SubTree Nodes.
        /// </summary>
        /// <returns></returns>
        public new List<int> GetNodeTypes()
        {
            return base.GetNodeTypes();
        }
        #endregion
    }

    /// <summary>
    /// XSwitchNode.  Inherits BNode.
    /// </summary>
    [Guid("11A62290-D0AA-414F-B8D8-222CC0607FAF")]
    public class BXSwitchNode : BNode, IBSPNode
    {
        #region Properties
        /// <summary>
        /// The Switch ID Number
        /// </summary>
        public SwitchID SwitchID
        {
            get { return (SwitchID)_Switch; }
            set { _Switch = (int)value; }
        }
        /// <summary>
        /// The File Offset relative to the Root Node where the SubTree exists.  The Node at this location will be processed after the current node.
        /// </summary>
        public long SubTreesPointer
        {
            get { return _SubtreePtr; }            
        }
        /// <summary>
        /// Number of children elements dependent upon this Switch.
        /// </summary>
        public int ChildCount
        {
            get { return _nChildren; }            
        }
        /// <summary>
        /// List of the Child Subtres for this Switch
        /// </summary>
        public List<long> ChildrenPointers
        {
            get { return _Children; }
        }
        /// <summary>
        /// Flags associated with this Node.
        /// </summary>
        public int Flags
        {
            get { return _Flags; }
            set { _Flags = value; }
        }
        /// <summary>
        /// Collection of the Nodes which make up the SubTrees of this Switch.
        /// </summary>
        public List<IBSPNode> SubTrees
        {
            get { return _SubTrees; }
            set { _SubTrees = value;
                _nChildren = _SubTrees.Count;
                _Children.Clear();
                foreach (IBSPNode node in _SubTrees)
                    _Children.Add(node.NodeAddress);
            }
        }
        /// <summary>
        /// The Total Size of the Node including all extra data and SubTrees.
        /// </summary>
        public new int TotalSize
        {
            get
            {
                int size = _Size;
                foreach (IBSPNode node in _SubTrees)
                    size += node.TotalSize;
                return size;
            }
        }
        /// <summary>
        /// Read-Only Count of the Number of <c>BSPNode</c> objects this Node represents including SubTrees.
        /// </summary>
        public new int NodeCount
        {
            get
            {
                int count = 1;
                foreach (IBSPNode node in _SubTrees)
                    count += node.NodeCount;
                return count;
            }
        }
        /// <summary>
        /// The offset of this Node relative to the Root Node.
        /// </summary>
        public new long NodeAddress
        {
            get { return _NodePtr; }
            set
            {
                _NodePtr = value;
            }
        }
        #endregion

        #region Fields
        private int _nChildren;
        private long _SubtreePtr;
        private int _Switch;
        private int _Flags;
        private List<long> _Children;
        private List<IBSPNode> _SubTrees;
        #endregion

        #region Constructors
        /// <summary>
        /// Returns an uninitialized object of type <see cref="BXSwitchNode"/>.
        /// </summary>
        public BXSwitchNode() : base()
        {
            _nChildren = 0;
            _SubtreePtr = -1;
            _Switch = 0;
            _NodeType = NodeType.XSWitchNode;
            _VFT = (int)_NodeType;
            _SubTrees = new List<IBSPNode>();
            _Children = new List<long>();
            _Size += 16;
        }

        /// <summary>
        /// Returns an object of type <see cref="BXSwitchNode"/>.
        /// </summary>
        /// <remarks>This Constructor should be used when reading from a LOD File.</remarks>
        /// <param name="stream"><see cref="Stream"/>;  Must be open and at the correct stream position prior to calling this function.</param>
        /// <param name="root">The file offset of the Root Node.</param>
        public BXSwitchNode(Stream stream, long root) : base(stream, root)
        {
            
            _NodeType = NodeType.XSWitchNode;
            _VFT = (int)_NodeType;
            _SubTrees = new List<IBSPNode>();
            _Children = new List<long>();
            try
            {
                using (BinaryReader reader = new BinaryReader(stream, System.Text.Encoding.Default, true))
                {
                    FillNode(reader);
                }
            }
            catch (Exception ex)
            {

                throw new Exception("There was an error reading the XSwitch Node at " + _NodePtr + "\r\n" + ex.Message, ex);
            }
        }
        #endregion

        #region Methods
        /// <summary>
        /// Print the properties for this Node in a multi-line format
        /// </summary>
        /// <returns>
        /// Multi-Line <see cref="string"/> with a new line character at the end.
        /// </returns> 
        public new string Print()
        {
            string retText = base.Print();
            retText += "Switch Number: " + _Switch + "\r\n";
            retText += "Flags: " + _Flags + "\r\n";
            foreach (IBSPNode node in _SubTrees)
                retText += node.Print();
            return retText;
        }

        /// <summary>
        /// Debug Printing contains more data than the normal Print function.
        /// </summary>
        /// <returns>Multi-Line <see cref="string"/> with a new line at the end.</returns> 
        public new string DebugPrint()
        {
            string retText = base.DebugPrint();
            retText += "******** Switch Node Data ********\r\n";
            retText += "(" + _lineCount + ") Switch Number: " + _Switch + "\r\n"; _lineCount += 4;
            retText += "(" + _lineCount + ") Flags: " + _Flags + "\r\n"; _lineCount += 4;
            retText += "(" + _lineCount + ") Number of Children: " + _nChildren + "\r\n"; _lineCount += 4;
            retText += "(" + _lineCount + ") SubTree Pointer: " + _SubtreePtr + "\r\n"; _lineCount += 4;
            return retText;
        }

        /// <summary>
        /// Writes the <c>BSPNode</c> Data to the <see cref="Stream"/>.
        /// </summary>
        /// <returns><see cref="bool"/> <c>true</c> if successful or <c>false</c> if unsuccessful.</returns>
        /// <param name="stream"><see cref="Stream"/> Must be open and at the correct position prior to calling this function.</param>
        public new bool Save(Stream stream)
        {
            _NodePtr = stream.Position - _RootPtr;
            UpdatePointers();
            base.Save(stream);
            
            try
            {
                using (BinaryWriter writer = new BinaryWriter(stream, System.Text.Encoding.Default, true))
                {
                    writer.Write(_Switch);
                    writer.Write(_Flags);
                    writer.Write(_nChildren);
                    writer.Write((int)_SubtreePtr);
                    foreach (long i in _Children)
                        writer.Write((int)i);
                    foreach (IBSPNode node in _SubTrees)
                    {
                        _lastNode = -1;
                        node.Save(writer.BaseStream);
                    }
                       
                }
            }
            catch (Exception ex)
            {
                throw new Exception("There was an error while writing the Switch Node at " + _NodePtr + "\r\n" + ex.Message, ex);
            }
            _lastNode = _NodePtr;
            return true;
        }

        /// <summary>
        /// Returns a list of the Node Types for this Node and any SubTree Nodes.
        /// </summary>
        /// <returns></returns>
        public new List<int> GetNodeTypes()
        {
            List<int> nodetypes = new List<int>
            {
                (int)_NodeType
            };
            foreach (IBSPNode node in _SubTrees)
                nodetypes.AddRange(node.GetNodeTypes());
            return nodetypes;
        }

        /// <summary>
        /// Updates the Root Pointer for the Node to reference.
        /// </summary>
        /// <param name="root"></param>
        public new void UpdateRoot(long root)
        {
            _RootPtr = root;
            foreach (IBSPNode node in SubTrees)
                node.UpdateRoot(root);
    
        }

        /// <summary>
        /// Helper function to read the data for this node
        /// </summary>
        /// <param name="reader">BinaryReader</param>
        /// <remarks>Binary Reader must be open and at the correct position</remarks>
        private new int FillNode(BinaryReader reader)
        {
            // Fill the Switch specific data
            _Switch = reader.ReadInt32();
            _Flags = reader.ReadInt32();
            _nChildren = reader.ReadInt32();
            _SubtreePtr = reader.ReadInt32();

            // Get the Children Pointers
            _Children = new List<long>();
            if (_nChildren > 0)
            {
                long returnPtr = reader.BaseStream.Position;
                reader.BaseStream.Position = _SubtreePtr + _RootPtr;
                for (int i = 0; i < _nChildren; i++)
                    _Children.Add(reader.ReadInt32());
            }

            _Size += (16 + (4 * _nChildren));
            return 1;
        }
        
        /// <summary>
        /// Updates Sizes and Pointers for the Node and SubTree Nodes 
        /// </summary>
        private void UpdatePointers()
        {
            // Set the SubTreePointer
            _SubtreePtr = _NodePtr + _Size;
            //Update the Pointers for each subtree            
            for (int i = 0; i < _nChildren; i++)
            {
                if (i == 0)
                {
                    _Children[i] = (_SubtreePtr + (4 * _nChildren));
                }
                else
                {
                    _Children[i] = (_SubtreePtr + (4 * _nChildren)) + _SubTrees[i - 1].TotalSize;
                }
                _SubTrees[i].NodeAddress = _Children[i];
            }
        }
        #endregion
    }

    /// <summary>
    /// BRenderControlNode.  Inherits BNode.
    /// </summary>
    [Guid("9C7FCB0A-FA84-49DA-B5A8-46DBDCBA4231")]
    public class BRenderControlNode : BNode, IBSPNode
    {
        #region Properties
        /// <summary>
        /// Render Control Type used to determine the Properties of this Node.
        /// </summary>
        public RenderControlType RenderControlType
        {
            get { return (RenderControlType)_RenderControlType; }
            set { _RenderControlType = (int)value; }
        }
        /// <summary>
        /// Data Arguments available to RenderControlType 0.
        /// </summary>
        public int[] DataArgs
        {
            get { return _DataArgs; }
            set { _DataArgs = value; }
        }
        /// <summary>
        /// ZBias float value available to RenderControlType 1.
        /// </summary>
        public float ZBias
        {
            get { return _Zbias; }
            set { _Zbias = value; }
        }
        /// <summary>
        /// Math Mode used in RenderControlType 2.
        /// </summary>
        public ushort MathMode
        {
            get { return _MathMode; }
            set { _MathMode = value; }
        }
        /// <summary>
        /// Math Mode Arguments used in RenderControlType 2.
        /// </summary>
        public byte[] Args
        {
            get { return _Args; }
            set { _Args = value; }
        }
        /// <summary>
        /// Result type of Math Mode Calculations.  Used in RenderControlType 2.
        /// </summary>
        public byte ResultType
        {
            get { return _ResultType; }
            set { _ResultType = value; }
        }
        /// <summary>
        /// Result ID.  Used in RenderControlType 2.
        /// </summary>
        public int ResultID
        {
            get { return _ResultID; }
            set { _ResultID = value; }
        }
        /// <summary>
        /// Math IDs used in Calculations for RenderControlType 2, ResultType 0.
        /// </summary>
        public uint[] MathIDs
        {
            get { return _MathID; }
            set { _MathID = value; }
        }
        /// <summary>
        /// Math float values.  Used in RenderControlType 2, ResultType 1.
        /// </summary>
        public float[] MathValues
        {
            get { return _MathValues; }
            set { _MathValues = value; }
        }
        #endregion

        #region Fields
        private int _RenderControlType;  //ENUM?
        private int[] _DataArgs;
        private float _Zbias;
        private ushort _MathMode;
        private byte[] _Args;
        private byte _ResultType;
        private int _ResultID;
        private uint[] _MathID;
        private float[] _MathValues;
        #endregion

        #region Constructors
        /// <summary>
        /// Returns an uninitialized object of type <see cref="BRenderControlNode"/>.
        /// </summary>
        public BRenderControlNode() : base()
        {
            _NodeType = NodeType.RenderControlNode;
            _VFT = (int)_NodeType;
            _RenderControlType = 0;
            _DataArgs = new int[0];
            _Zbias = 0;
            _MathMode = 0;
            _Args = new byte[0];
            _ResultType = 0;
            _ResultID = 0;
            _MathID = new uint[0];
            _MathValues = new float[0];
            _Size += 36;
        }

        /// <summary>
        /// Returns an object of type <see cref="BRenderControlNode"/>.
        /// </summary>
        /// <remarks>This Constructor should be used when reading from a LOD File.</remarks>
        /// <param name="stream"><see cref="Stream"/>;  Must be open and at the correct stream position prior to calling this function.</param>
        /// <param name="root">The file offset of the Root Node.</param>
        public BRenderControlNode(Stream stream, long root) : base(stream, root)
        {
            
            _NodeType = NodeType.RenderControlNode;
            _VFT = (int)_NodeType;
            _DataArgs = new int[0];
            _Zbias = 0;
            _MathMode = 0;
            _Args = new byte[0];
            _ResultType = 0;
            _ResultID = 0;
            _MathID = new uint[0];
            _MathValues = new float[0];
            try
            {
                using (BinaryReader reader = new BinaryReader(stream, System.Text.Encoding.Default, true))
                {
                    _RenderControlType = reader.ReadInt32();
                    switch (_RenderControlType)
                    {
                        case 0:
                            _DataArgs = new int[8];
                            for (int i = 0; i < 8; i++)
                                _DataArgs[i] = reader.ReadInt32();
                            _Size += 36;
                            break;
                        case 1:
                            reader.BaseStream.Position += 16;
                            _Zbias = reader.ReadSingle();
                            _Size += 36;
                            break;
                        case 2:
                            _Args = new byte[5];
                            _MathMode = reader.ReadUInt16();
                            for (int i = 0; i < 5; i++)
                                _Args[i] = reader.ReadByte();
                            _ResultType = reader.ReadByte();
                            _ResultID = reader.ReadUInt16();
                            if (_ResultType == 0)
                            {
                                _MathID = new uint[5];
                                for (int i = 0; i < 5; i++)
                                    _MathID[i] = reader.ReadUInt16();
                                _Size += 36;
                            }
                            else
                            {
                                _MathValues = new float[5];
                                for (int i = 0; i < 5; i++)
                                    _MathValues[i] = reader.ReadSingle();
                                _Size += 36;
                            }
                            break;
                    }
                }
            }
            catch (Exception ex)
            {

                throw new Exception("There was an error reading the Render Control Node at " + _NodePtr + "\r\n" + ex.Message, ex);
            }
            
        }
        #endregion

        #region Methods
        /// <summary>
        /// Print the properties for this Node in a multi-line format
        /// </summary>
        /// <returns>
        /// Multi-Line <see cref="string"/> with a new line character at the end.
        /// </returns> 
        public new string Print()
        {
            string retText = base.Print();
            retText += "Render Control Type: " + _RenderControlType + "\r\n";
            switch (_RenderControlType)
            {
                case 0:
                    for (int i = 0; i < 8; i++)
                        retText += "Data Argument " + i + ": " + _DataArgs[i] + "\r\n";
                    break;

                case 1:
                    retText += "ZBias: " + _Zbias + "\r\n";
                    break;

                case 2:
                    retText += "Math Mode: " + _MathMode + "\r\n";
                    for (int i = 0; i < 5; i++)
                        retText += "Argument " + i + ": " + _Args[i] + "\r\n";
                    retText += "Result Type: " + _ResultType + "\r\n";
                    retText += "Result ID: " + _ResultID + "\r\n";
                    if (_ResultType == 0)
                        for (int i = 0; i < 5; i++)
                            retText += "Math ID: " + _MathID[i] + "\r\n";
                    else
                        for (int i = 0; i < 5; i++)
                            retText += "Math Value: " + _MathValues[i] + "\r\n";
                    break;
            }
            return retText;
        }

        /// <summary>
        /// Debug Printing contains more data than the normal Print function.
        /// </summary>
        /// <returns>Multi-Line <see cref="string"/> with a new line at the end.</returns> 
        public new string DebugPrint()
        {
            string retText = base.DebugPrint();
            retText += "******** RenderControl Node ********\r\n";
            retText += "(" + _lineCount + ") Render Control Type: " + _RenderControlType + "\r\n"; _lineCount += 4;
            switch (_RenderControlType)
            {
                case 0:
                    for (int i = 0; i < 8; i++)
                    { retText += "(" + _lineCount + ") Data Argument " + i + ": " + _DataArgs[i] + "\r\n"; _lineCount += 4; }
                    break;

                case 1:
                    _lineCount += 16;
                    retText += "(" + _lineCount + ") ZBias: " + _Zbias + "\r\n"; _lineCount += 4;
                    break;

                case 2:
                    retText += "(" + _lineCount + ") Math Mode: " + _MathMode + "\r\n"; _lineCount += 2;
                    for (int i = 0; i < 5; i++)
                    { retText += "(" + _lineCount + ") Argument " + i + ": " + _Args[i] + "\r\n"; _lineCount++; }
                    retText += "(" + _lineCount + ") Result Type: " + _ResultType + "\r\n"; _lineCount++;
                    retText += "(" + _lineCount + ") Result ID: " + _ResultID + "\r\n"; _lineCount += 4;
                    if (_ResultType == 0)
                        for (int i = 0; i < 5; i++)
                        { retText += "(" + _lineCount + ") Math ID: " + _MathID[i] + "\r\n"; _lineCount += 4; }
                    else
                        for (int i = 0; i < 5; i++)
                        { retText += "(" + _lineCount + ") Math Value: " + _MathValues[i] + "\r\n"; _lineCount += 4; }
                    break;
            }
            return retText;
        }

        /// <summary>
        /// Writes the <c>BSPNode</c> Data to the <see cref="Stream"/>.
        /// </summary>
        /// <returns><see cref="bool"/> <c>true</c> if successful or <c>false</c> if unsuccessful.</returns>
        /// <param name="stream"><see cref="Stream"/> Must be open and at the correct position prior to calling this function.</param>
        public new bool Save(Stream stream)
        {
            _NodePtr = stream.Position - _RootPtr;
            base.Save(stream);
            try
            {
                using (BinaryWriter writer = new BinaryWriter(stream, System.Text.Encoding.Default, true))
                {
                    writer.Write(_RenderControlType);
                    switch (_RenderControlType)
                    {
                        case 0:
                            for (int i = 0; i < 8; i++)
                                writer.Write(_DataArgs[i]);
                            break;
                        case 1:
                            for (int i = 0; i < 16; i++)
                                writer.Write((byte)0);
                            writer.Write((Single)_Zbias);
                            // Buffers for Union
                            writer.Write(0);
                            writer.Write(0);
                            writer.Write(0);
                            break;
                        case 2:
                            writer.Write(_MathMode);
                            for (int i = 0; i < 5; i++)
                                writer.Write(_Args[i]);
                            writer.Write(_ResultType);
                            writer.Write((UInt16)_ResultID);
                            if (_ResultType == 0)
                            {
                                for (int i = 0; i < 5; i++)
                                    writer.Write((UInt16)_MathID[i]);
                                writer.Write(0);
                                writer.Write(0);
                                writer.Write(0);
                            }
                            else
                            {
                                for (int i = 0; i < 5; i++)
                                    writer.Write((Single)_MathValues[i]);
                                writer.Write((byte)0);
                                writer.Write((byte)0);
                            }
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("There was an error while writing the Render Control Node at " + _NodePtr + "\r\n" + ex.Message, ex);
            }
            _lastNode = _NodePtr;
            return true;
        }
        #endregion
    }

    /// <summary>
    /// BCullNode.  Inherits BNode.
    /// </summary>
    [Guid("C8F7B7EC-4FA7-4C7B-8AEB-14B2556FBEBC")]
    public class BCullNode : BNode, IBSPNode
    {
        #region Properties
        /// <summary>
        /// Cull Node A Component.
        /// </summary>
        public float A
        {
            get { return _A; }
            set { _A = value; }
        }
        /// <summary>
        /// Cull Node B Component.
        /// </summary>
        public float B
        {
            get { return _B; }
            set { _B = value; }
        }
        /// <summary>
        /// Cull Node C Component.
        /// </summary>
        public float C
        {
            get { return _C; }
            set { _C = value; }
        }
        /// <summary>
        /// Cull Node D Component.
        /// </summary>
        public float D
        {
            get { return _D; }
            set { _D = value; }
        }
        /// <summary>
        /// The File Offset to the Front Node SubTree. 
        /// </summary>
        public long FrontNodePointer
        {
            get { return _FrontNode; }
            set {
                _FrontNode = value;
            }
        }
        /// <summary>
        /// The File Offset to the Back Node SubTree. 
        /// </summary>
        public long BackNodePointer
        {
            get { return _BackNode; }
            set {
                _BackNode = value;
            }
        }
        /// <summary>
        /// Collection of the Nodes which make up the Front Tree of this Cull Node.
        /// </summary>
        public List<IBSPNode> FrontTree
        {
            get { return _FrontTree; }
            set {
                _FrontTree = value;
            }
        }
        /// <summary>
        /// Collection of the Nodes which make up the Back Tree of this Cull Node.
        /// </summary>
        public List<IBSPNode> BackTree
        {
            get { return _BackTree; }
            set {
                _BackTree = value;
            }
        }
        /// <summary>
        /// The Total Size of the Node including all extra data and SubTrees.
        /// </summary>
        public new int TotalSize
        {
            get
            {
                int size = _Size;
                foreach (IBSPNode node in FrontTree.Concat(BackTree))
                    size += node.TotalSize;
                return size;
            }
        }
        /// <summary>
        /// The offset of this Node relative to the Root Node.
        /// </summary>
        public new long NodeAddress
        {
            get { return _NodePtr; }
            set
            {
                _NodePtr = value;
            }
        }
        #endregion

        #region Fields
        private float _A;
        private float _B;
        private float _C;
        private float _D;
        private long _FrontNode;
        private long _BackNode;
        private List<IBSPNode> _FrontTree;
        private List<IBSPNode> _BackTree;
        #endregion

        #region Constructors
        /// <summary>
        /// Returns an uninitialized object of type <see cref="BCullNode"/>.
        /// </summary>
        public BCullNode() : base()
        {
            _A = _B = _C = _D = 0;
            _FrontNode = _BackNode = 0;
            _NodeType = NodeType.LightStringNode;
            _VFT = (int)_NodeType;
            _FrontTree = new List<IBSPNode>();
            _BackTree = new List<IBSPNode>();
            _Size += 24;
        }

        /// <summary>
        /// Returns an initialized object of type <see cref="BCullNode"/>.
        /// </summary>
        /// <remarks>This Constructor should be used when reading from a LOD File.</remarks>
        /// <param name="stream"><see cref="Stream"/>;  Must be open and at the correct stream position prior to calling this function.</param>
        /// <param name="root">The file offset of the Root Node.</param>
        public BCullNode(Stream stream, long root) : base(stream, root)
        {
            
            _NodeType = NodeType.LightStringNode;
            _VFT = (int)_NodeType;            
            _FrontTree = new List<IBSPNode>();
            _BackTree = new List<IBSPNode>();
            try
            {
                using (BinaryReader reader = new BinaryReader(stream, System.Text.Encoding.Default, true))
                {
                    _A = reader.ReadInt32();
                    _B = reader.ReadInt32();
                    _C = reader.ReadInt32();
                    _D = reader.ReadInt32();
                    _FrontNode = reader.ReadInt32();
                    _BackNode = reader.ReadInt32();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("There was an error reading the Cull Node at " + _NodePtr + "\r\n" + ex.Message, ex);
            }
            _Size += 24;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Print the properties for this Node in a multi-line format
        /// </summary>
        /// <returns>
        /// Multi-Line <see cref="string"/> with a new line character at the end.
        /// </returns> 
        public new string Print()
        {
            string retText = base.Print() + "\r\n";
            retText += "A: " + _A + "\r\n";
            retText += "B: " + _B + "\r\n";
            retText += "C: " + _C + "\r\n";
            retText += "D: " + _D + "\r\n";
            retText += "Front Node: " + _FrontNode + "\r\n";
            retText += "Back Node: " + _BackNode + "\r\n";
            return retText;
        }

        /// <summary>
        /// Debug Printing contains more data than the normal Print function.
        /// </summary>
        /// <returns>Multi-Line <see cref="string"/> with a new line at the end.</returns> 
        public new string DebugPrint()
        {
            string retText = base.DebugPrint() + "\r\n";
            retText += "******** LightString Node Data ********\r\n";
            retText += "(" + _lineCount + ") A: " + _A + "\r\n"; _lineCount += 4;
            retText += "(" + _lineCount + ") B: " + _B + "\r\n"; _lineCount += 4;
            retText += "(" + _lineCount + ") C: " + _C + "\r\n"; _lineCount += 4;
            retText += "(" + _lineCount + ") D: " + _D + "\r\n"; _lineCount += 4;
            retText += "(" + _lineCount + ") Front Node: " + _FrontNode + " (" + (_RootPtr + _FrontNode) + ")\r\n"; _lineCount += 4;
            retText += "(" + _lineCount + ") Back Node: " + _BackNode + " (" + (_RootPtr + _BackNode) + ")\r\n"; _lineCount += 4;
            return retText;
        }

        /// <summary>
        /// Writes the <c>BSPNode</c> Data to the <see cref="Stream"/>.
        /// </summary>
        /// <returns><see cref="bool"/> <c>true</c> if successful or <c>false</c> if unsuccessful.</returns>
        /// <param name="stream"><see cref="Stream"/> Must be open and at the correct position prior to calling this function.</param>
        public new bool Save(Stream stream)
        {
            _NodePtr = stream.Position - _RootPtr;
            UpdatePointers();
            base.Save(stream);
            BinaryWriter writer = new BinaryWriter(stream);
            try
            {
                writer.Write(_A);
                writer.Write(_B);
                writer.Write(_C);
                writer.Write(_D);
                writer.Write((int)_FrontNode);
                writer.Write((int)_BackNode);
                _lastNode = -1;
                foreach (IBSPNode node in _FrontTree)
                    node.Save(writer.BaseStream);
                _lastNode = -1;
                foreach (IBSPNode node in _BackTree)
                    node.Save(writer.BaseStream);
            }
            catch
            {
                throw new Exception("There was an error while writing the Cull Node at " + _NodePtr);
            }
            _lastNode = _NodePtr;
            return true;
        }

        /// <summary>
        /// Updates Sizes and Pointers for the Node and SubTree Nodes 
        /// </summary>
        private void UpdatePointers()
        {
            
            int _TreeSize = 0;
            if (_FrontTree.Count > 0)
            {
                foreach (IBSPNode node in _FrontTree)
                    _TreeSize += node.TotalSize;
                _FrontNode = _NodePtr + 32 + (_TreeSize - _FrontTree[0].TotalSize);
                _FrontTree[0].NodeAddress = _FrontNode;
            }
            else
                _FrontNode = -1;

            if (_BackTree.Count > 0)
            {
                _BackNode = _NodePtr + 32 + _TreeSize;
                _TreeSize = 0;
                foreach (IBSPNode node in _BackTree)
                    _TreeSize += node.TotalSize;
                _BackNode += _TreeSize - _BackTree[0].TotalSize;
                _BackTree[0].NodeAddress = _BackNode;
            }
            else
                _BackNode = -1;
        }
        #endregion
    } 
    #endregion    
}
