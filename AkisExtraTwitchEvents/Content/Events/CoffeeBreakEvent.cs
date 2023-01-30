﻿using Klei.AI;
using UnityEngine;

namespace Twitchery.Content.Events
{
    public class CoffeeBreakEvent : ITwitchEvent
    {
        public string GetID() => "CoffeeBreak";

        public bool Condition(object data) => true;

        public void Run(object data)
        {
            foreach (MinionIdentity minion in Components.LiveMinionIdentities)
            {
                new EmoteChore(
                    minion.GetComponent<ChoreProvider>(), 
                    Db.Get().ChoreTypes.EmoteHighPriority, 
                    TEmotes.coffeeBreak);

                if (minion.TryGetComponent(out Effects effects))
                {
                    effects.Add(TEffects.CAFFEINATED, true);
                }
            }

            ONITwitchLib.ToastManager.InstantiateToast("Coffee break", "All Duplicants are taking a well deserved break.");
        }
    }
}
