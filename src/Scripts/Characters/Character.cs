using Anubis.Characters.Attributes;
using Anubis.Characters.Equipment;
using Anubis.Items;

namespace Anubis.Characters;

public abstract partial class Character : CharacterBody2D
{
    [Export] public string CharacterName { get; set; } = "Character";
    [Export] public uint CharacterLevel { get; set; }
    [Export] public CharacterAttributes Attributes { get; set; } = new();
    [Export] public CharacterEquipment Equipment { get; set; } = new();
    [Export] public Inventory Inventory { get; set; } = new();
}
