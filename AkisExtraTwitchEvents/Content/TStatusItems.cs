﻿using Database;
using Twitchery.Content.Defs;
using Twitchery.Content.Scripts;

namespace Twitchery.Content
{
    public class TStatusItems
    {
        public static StatusItem CalorieStatus;
		public static StatusItem PolymorphStatus;
		public static StatusItem GoldStruckStatus;


		public static void Register(MiscStatusItems parent)
        {
            PolymorphStatus = parent.Add(new StatusItem(
				"AkisExtraTwitchEvents_PolymorphStatus",
				"MISC",
				"status_item_doubleexclamation",
				StatusItem.IconType.Info,
				NotificationType.Neutral,
				false,
				OverlayModes.None.ID));

			PolymorphStatus.SetResolveStringCallback((str, data) =>
			{
                return data is AETE_PolymorphCritter polymorph
                    ? string.Format(
                        str, 
                        polymorph.GetProperName(), 
                        polymorph.originalSpeciesname, 
                        GameUtil.GetFormattedTime(polymorph.duration - polymorph.elapsedTime))
                    : str;
			});

			CalorieStatus = parent.Add(new StatusItem(
                "AkisExtraTwitchEvents_CalorieStatus",
                "MISC",
                "status_item_doubleexclamation",
                StatusItem.IconType.Info,
                NotificationType.Neutral,
                false,
                OverlayModes.None.ID));

            CalorieStatus.SetResolveStringCallback((str, data) =>
            {
                if (data is Radish radish)
                {
                    var amount = radish.raddishStorage.MassStored();
                    return string.Format(str, GameUtil.GetFormattedCaloriesForItem(RawRadishConfig.ID, amount));
                }

                return str;
            });

			GoldStruckStatus = parent.Add(new StatusItem(
				"AkisExtraTwitchEvents_GoldStruckStatus",
				"MISC",
				"status_item_doubleexclamation",
				StatusItem.IconType.Exclamation,
				NotificationType.BadMinor,
				false,
				OverlayModes.None.ID));

			GoldStruckStatus.SetResolveStringCallback((str, data) =>
			{
				return data is MidasEntityContainer container
					? string.Format(str, container.GetTimeLeft())
					: str;
			});
		}
    }
}