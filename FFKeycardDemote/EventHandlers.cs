using System.Linq;
using Exiled.Events.EventArgs;
using System.Collections.Generic;
using Exiled.API.Extensions;

namespace FFKeycardDemote
{
    class EventHandlers
    {
        public void OnDying(DyingEventArgs ev)
        {
            var routeOne = FFKeycardDemote.Instance.Config.KeycardRouteOne;
            var routeTwo = FFKeycardDemote.Instance.Config.KeycardRouteTwo;

            if (ev.Killer.Side == ev.Target.Side)
            {
                IEnumerable<Inventory.SyncItemInfo> keycards = ev.Killer.Inventory.items.Where(x => x.id.IsKeycard());
                
                foreach (Inventory.SyncItemInfo keycard in keycards)
                {
                    ev.Killer.Inventory.items.Remove(keycard);


                    if (routeOne.Contains(keycard.id))
                    {
                        ev.Killer.Inventory.AddNewItem(routeOne.ElementAt(routeOne.IndexOf(keycard.id - 1)));
                    }
                    else if (routeTwo.Contains(keycard.id))
                    {
                        ev.Killer.Inventory.AddNewItem(routeTwo.ElementAt(routeTwo.IndexOf(keycard.id - 1)));
                    }

                }

                if (keycards.IsEmpty() && FFKeycardDemote.Instance.Config.KillOnNoKeycard)
                {
                    ev.Killer.Kill(DamageTypes.FriendlyFireDetector);
                }
            }
        }
    }
}
