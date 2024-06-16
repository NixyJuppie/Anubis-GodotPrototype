using System.Collections.Generic;
using Anubis.Items;

namespace Anubis.Characters.Loot;

// TODO: #22 Item randomization
[GlobalClass]
public abstract partial class LootTable : Resource
{
    public abstract ICollection<Item> GetItems();
}