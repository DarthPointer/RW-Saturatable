using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaturatableRW
{
    class SaturatableRWSettings : GameParameters.CustomParameterNode
    {
        #region Fields

        [GameParameters.CustomParameterUI("Enable discharge for propellant", newGameOnly = false, toolTip = "Reaction wheels get buttons in RW window to toggle discharging torque using propellant")]
        public bool enableDischargeForPropellant = false;

        [GameParameters.CustomParameterUI("Enable reasonless recovery", newGameOnly = false, toolTip = "Reaction wheels recover their torque \"for no reason\" (with no reaction passed back to vessel)")]
        public bool enableReasonlessRecovery = false;

        [GameParameters.CustomFloatParameterUI("Reasonless recovery scale", newGameOnly = false, displayFormat = "F2", minValue = 0.00f, maxValue = 10f, toolTip = "How fast reasonless recovery goes. 1 stands for legacy unmodified scale")]
        public float reasonlessRecoveryScale = 1f;

        #endregion

        #region StaticReadableProperties

        private static SaturatableRWSettings Instance
        {
            get
            {
                return HighLogic.CurrentGame.Parameters.CustomParams<SaturatableRWSettings>();
            }
        }

        public static bool EnableDischargeForPropellant
        {
            get
            {
                return Instance.enableDischargeForPropellant;
            }
        }

        public static bool EnableReasonlessRecovery
        {
            get
            {
                return Instance.enableReasonlessRecovery;
            }
        }

        public static float ReasonlessRecoveryScale
        {
            get
            {
                return Instance.reasonlessRecoveryScale;
            }
        }

        #endregion

        #region CustomParameterNode

        public override GameParameters.GameMode GameMode
        {
            get
            {
                return GameParameters.GameMode.ANY;
            }
        }

        public override string Section
        {
            get
            {
                return "(Semi-) Saturatable Reacion Wheels";
            }
        }

        public override string DisplaySection
        {
            get
            {
                return Section;
            }
        }

        public override string Title
        {
            get
            {
                return "Rotation in vacuum is twice difficult";
            }
        }

        public override int SectionOrder
        {
            get
            {
                return 1;
            }
        }

        public override bool HasPresets
        {
            get
            {
                return false;
            }
        }

        #endregion
    }
}
