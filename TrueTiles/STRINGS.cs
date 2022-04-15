﻿namespace TrueTiles
{
    internal class STRINGS
    {
        public class TEXTUREPACKS
        {
            public static LocString INFO = "by <b>{0}</b>\n";
            public static LocString AUTHOR = "by <b>{0}</b>";
            public static LocString TEXTURE_COUNT = "{0} textures";

            public class EXTERNAL_SAVE_DIALOG
            {
                public static LocString TEXT = "Save settings externally? This will makre sure settings will stay after updates.";

                public static LocString BUTTON_EXTERNAL = "Sure (recommended)";
                public static LocString BUTTON_LOCAL = "No, keep local";
            }

            public class DEFAULT
            {
                public static LocString NAME = "Default";
                public static LocString DESCRIPTION = "The default look of True Tiles.";
            }

            public class MATERIAL
            {
                public static LocString NAME = "Material Overlay";
                public static LocString DESCRIPTION = "Bleached, colorless tiles that are arguably better suited to be tinted by Material Colors or Material Color Tiles.\nRecommended to use with either of those mods also installed.";
            }

            public class BEAUTIFULGRANITE
            {
                public static LocString NAME = "Beautiful Granite";
                public static LocString DESCRIPTION = "Sparkly and smooth Granite, a request of Sonia_k.";
            }

            public class CUTESYCARPET
            {
                public static LocString NAME = "Cutesy Carpets";
                public static LocString DESCRIPTION = "";
            }
        }

        public class UI
        {
            public class SETTINGSDIALOG
            {
                public static LocString VERSIONLABEL = "{0}";

                public class TITLEBAR
                {
                    public static LocString LABEL = "Tile Textures";
                }

                public class BUTTONS
                {
                    public class CANCELBUTTON
                    {
                        public static LocString TEXT = "Cancel";
                    }

                    public class OK
                    {
                        public static LocString TEXT = "Apply";
                    }

                    public class EXTERNALSAVECONFIRM
                    {
                        public static LocString INFO = "Save settings outside mods folder";
                        public static LocString TOOLTIP = "Recommended to enable. \nSaving settings outside means your changes will persist after the mod or game updates; but will not be removed when you uninstall the mod.\n\n The path to external settings is: {0}.";
                    }
                }

                public class SCROLLVIEW
                {
                    public class VIEWPORT
                    {
                        public class CONTENT
                        {
                            public class ENTRY
                            {
                                public class TITLE
                                {
                                    public static LocString TEXT = "N/A";
                                }

                                public static LocString INFO = "N/A";

                                public class BUTTONS
                                {
                                    public class OPEN
                                    {
                                        public static LocString LABEL = "Open Folder";
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
