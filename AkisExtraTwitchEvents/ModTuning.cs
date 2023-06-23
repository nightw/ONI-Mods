﻿namespace Twitchery
{
	public class ModTuning
	{
#if DEBUG_DURATIONS
		public const float 
			DOUBLE_TROUBLE_DURATION = 10f,
			POLYMOPRH_DURATION = 10f,
			EGG_DURATION = 10f,
			INVISIBLE_LIQUIDS_DURATION = 10f,
			MIDAS_TOUCH_DURATION = 30f,
			MIDAS_TOUCH_EFFECT_DURATION = 30f,
			RETRO_VISION_DURATION = 30f;
#else
		public const float
			DOUBLE_TROUBLE_DURATION = 600f,
			POLYMOPRH_DURATION = 600f,
			EGG_DURATION = 240f,
			INVISIBLE_LIQUIDS_DURATION = 600f,
			MIDAS_TOUCH_DURATION = 15f,
			MIDAS_TOUCH_EFFECT_DURATION = 600f,
			RETRO_VISION_DURATION = 180f;
#endif
	}
}
