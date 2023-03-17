﻿namespace Backwalls
{
    public class STRINGS
    {
        public class BUILDINGS
        {
            public class PREFABS
            {
                public class BACKWALL_DECORATIVEBACKWALL
                {
                    public static LocString NAME = "Decorative Backwall";
                    public static LocString DESC = "todo";
                    public static LocString EFFECT = "Does not prevent gas and liquid loss in Space.";
                }
                public class BACKWALL_SEALEDBACKWALL
                {
                    public static LocString NAME = "Sealed Backwall";
                    public static LocString DESC = "todo";
                    public static LocString EFFECT = global::STRINGS.BUILDINGS.PREFABS.EXTERIORWALL.EFFECT;
                }
            }
        }

        public class MISC
        {
            public static LocString UNNAMED_BACKWALL_VARIANT = "Unnamed";
            public static LocString PIP_BACKWALL_VARIANT = "Pip";
            public static LocString CAT_BACKWALL_VARIANT = "Cat";
            public static LocString STRIPE_BACKWALL_VARIANT = "Stripe";
            public static LocString NONSENSE_BACKWALL_VARIANT = "Nonsense Sepia";
            public static LocString DOTTY_BACKWALL_VARIANT = "Dotted";
        }

        public class UI
        {
            public class SETTINGSDIALOG
            {
                public static class TITLE
                {
                    public static LocString TITLETEXT = "Backwalls Settings";
                }

                public static class BUTTONS
                {
                    public static class STEAMBUTTON
                    {
                        public static LocString TEXT = "Steam Workshop";
                    }

                    public static class CANCELBUTTON
                    {
                        public static LocString TEXT = "Cancel";
                    }

                    public static class GITHUBBUTTON
                    {
                        public static LocString TEXT = "Github";
                    }

                    public static class OK
                    {
                        public static LocString TEXT = "Apply";
                    }
                }

                public static class CONTENT
                {
                    public static class COLOR
                    {
                        public static LocString LABEL = "Default Color";
                    }

                    public static class PATTERN
                    {
                        public static LocString LABEL = "Default Pattern";
                    }

                    public static class DECORATIVEBACKWALL
                    {
                        public static LocString LABEL = "Decorative Backwall";

                        public static class DECOR
                        {
                            public static LocString LABEL = "Decor";
                        }

                        public static class RANGE
                        {
                            public static LocString LABEL = "Range";
                        }
                    }

                    public static class SEALEDBACKWALL
                    {
                        public static LocString LABEL = "Sealed Backwall";

                        public static class DECOR
                        {
                            public static LocString LABEL = "Decor";
                        }

                        public static class RANGE
                        {
                            public static LocString LABEL = "Range";
                        }
                    }

                    public static class RENDERLAYERPRESET
                    {
                        public static LocString LABEL = "Render backwalls";
                        public static LocString CHOICELABEL = "N/A"; public class LAYER
                        {
                            public static LocString TITLE = "Layer";
                            public static LocString TOOLTIP = "Where to render the backwalls";

                            public class AUTOMATIC
                            {
                                public static LocString TITLE = "Automatic";
                                public static LocString DESCRIPTION = "Act the same as drywalls.";
                            }

                            public class HIDEPIPES
                            {
                                public static LocString TITLE = "Hide Pipes";
                                public static LocString DESCRIPTION = "Render in front of pipes.";
                            }

                            public class BEHINDPIPES
                            {
                                public static LocString TITLE = "Behind Pipes";
                                public static LocString DESCRIPTION = "Render behind pipes.";
                            }
                        }
                    }
                }

                public class DEFAULTCOLOR
                {
                    public static LocString TITLE = "Default Color";
                    public static LocString TOOLTIP = "What color to place by default";
                }

                public class DEFAULTPATTERN
                {
                    public static LocString TITLE = "Default Pattern";
                    public static LocString TOOLTIP = "What pattern to place by default";
                }
            }

            public class WALLSIDESCREEN
            {
                public static LocString TITLE = "Backwall appearance";

                public class CONTENTS
                {
                    public class COPYTOGGLES
                    {
                        public class PATTERNTOGGLE
                        {
                            public class TOGGLE
                            {
                                public static LocString LABEL = "Copy Pattern";
                            }
                        }

                        public class COLORTOGGLE
                        {
                            public class TOGGLE
                            {
                                public static LocString LABEL = "Copy Color";
                            }
                        }

                        public class WARNING
                        {
                            public static LocString LABEL = "Nothing will be copied!";
                        }
                    }
                }
            }
        }
    }
}
