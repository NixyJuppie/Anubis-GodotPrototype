using Anubis.Characters;

namespace Anubis.UI;

public partial class CharacterInfoView : Control
{
    private RichTextLabel _infoText = null!;
    private string _infoTextTemplate = null!;

    [Export] public Character? Character { get; set; }

    public override void _Ready()
    {
        _infoText = GetNode<RichTextLabel>("%InfoText");
        _infoTextTemplate = _infoText.Text;
        UpdateView();
    }

    public void UpdateView()
    {
        if (Character is null)
        {
            _infoText.Text = $"[color=red]{nameof(CharacterInfoView)} must have a character assigned[/color]";
            return;
        }

        RequiredPropertyNotAssignedException.ThrowIfNull(Character.ComputedAttributes?.Health);
        RequiredPropertyNotAssignedException.ThrowIfNull(Character.ComputedAttributes?.Stamina);
        RequiredPropertyNotAssignedException.ThrowIfNull(Character.ComputedAttributes?.Mana);
        RequiredPropertyNotAssignedException.ThrowIfNull(Character.ComputedAttributes?.Strength);
        RequiredPropertyNotAssignedException.ThrowIfNull(Character.ComputedAttributes?.Agility);
        RequiredPropertyNotAssignedException.ThrowIfNull(Character.ComputedAttributes?.Intelligence);
        RequiredPropertyNotAssignedException.ThrowIfNull(Character.ComputedAttributes?.Luck);
        RequiredPropertyNotAssignedException.ThrowIfNull(Character.ComputedDamage);
        RequiredPropertyNotAssignedException.ThrowIfNull(Character.ComputedResistance);

        _infoText.Text = _infoTextTemplate
            .Replace("{Name}", Character.CharacterName)
            .Replace("{Level}", Character.CharacterLevel.ToString())
            .Replace("{Health}", Character.ComputedAttributes.Health.ToString())
            .Replace("{Stamina}", Character.ComputedAttributes.Stamina.ToString())
            .Replace("{Mana}", Character.ComputedAttributes.Mana.ToString())
            .Replace("{Strength}", Character.ComputedAttributes.Strength.ToString())
            .Replace("{Agility}", Character.ComputedAttributes.Agility.ToString())
            .Replace("{Intelligence}", Character.ComputedAttributes.Intelligence.ToString())
            .Replace("{Luck}", Character.ComputedAttributes.Luck.ToString())
            .Replace("{SlashDamage}", Character.ComputedDamage.Slash.ToString())
            .Replace("{PierceDamage}", Character.ComputedDamage.Pierce.ToString())
            .Replace("{BluntDamage}", Character.ComputedDamage.Blunt.ToString())
            .Replace("{FireDamage}", Character.ComputedDamage.Fire.ToString())
            .Replace("{ColdDamage}", Character.ComputedDamage.Cold.ToString())
            .Replace("{LightningDamage}", Character.ComputedDamage.Lightning.ToString())
            .Replace("{NatureDamage}", Character.ComputedDamage.Nature.ToString())
            .Replace("{SlashResistance}", Character.ComputedResistance.Slash.ToString())
            .Replace("{PierceResistance}", Character.ComputedResistance.Pierce.ToString())
            .Replace("{BluntResistance}", Character.ComputedResistance.Blunt.ToString())
            .Replace("{FireResistance}", Character.ComputedResistance.Fire.ToString())
            .Replace("{ColdResistance}", Character.ComputedResistance.Cold.ToString())
            .Replace("{LightningResistance}", Character.ComputedResistance.Lightning.ToString())
            .Replace("{NatureResistance}", Character.ComputedResistance.Nature.ToString());
    }
}