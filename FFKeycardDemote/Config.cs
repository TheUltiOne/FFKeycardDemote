using System.Collections.Generic;
using System.ComponentModel;
using Exiled.API.Interfaces;

namespace FFKeycardDemote
{
    public sealed class Config : IConfig
    {
        public bool IsEnabled { get; set; } = true;

        [Description("Sets the route 1 for keycards")]
        public List<ItemType> KeycardRouteOne { get; set; } = new List<ItemType>() { ItemType.KeycardJanitor, ItemType.KeycardScientist, ItemType.KeycardScientistMajor, ItemType.KeycardSeniorGuard, ItemType.KeycardNTFLieutenant, ItemType.KeycardNTFCommander, ItemType.KeycardO5 };

        [Description("Sets the route 2 for keycards | You can leave this empty if you only want 1 route")]
        public List<ItemType> KeycardRouteTwo { get; set; } = new List<ItemType>() { ItemType.KeycardZoneManager, ItemType.KeycardGuard, ItemType.KeycardContainmentEngineer, ItemType.KeycardFacilityManager, ItemType.KeycardO5 };

        [Description("Sets if the Attacker is killed if they don't have a keycard")]
        public bool KillOnNoKeycard { get; set; } = true;
    }
}
