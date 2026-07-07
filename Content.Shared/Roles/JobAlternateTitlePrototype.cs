using Robust.Shared.Enums;
using Robust.Shared.Prototypes;

namespace Content.Shared.Roles;

/// <summary>
/// Defines an alternate, player-selectable display title for a <see cref="JobPrototype"/>.
/// </summary>
[Prototype("jobAlternateTitle")]
public sealed partial class JobAlternateTitlePrototype : IPrototype
{
    [IdDataField]
    public string ID { get; private set; } = default!;

    /// <summary>
    /// Gender-neutral (or default) display name. Localization string ID.
    /// </summary>
    [DataField]
    public string Name = default!;

    /// <summary>
    /// Optional override shown when the character's gender is Female.
    /// </summary>
    [DataField]
    public string? FemaleName;

    /// <summary>
    /// Optional override shown when the character's gender is Male.
    /// </summary>
    [DataField]
    public string? MaleName;

    /// <summary>
    /// Optional requirements (playtime, whitelist, etc.) that must be met before
    /// this alternate title can be selected. If unmet, the option shows locked.
    /// </summary>
    [DataField]
    public HashSet<JobRequirement>? Requirements;

    public string LocalizedName(Gender? gender)
    {
        var stringId = gender switch
        {
            Gender.Female => FemaleName ?? Name,
            Gender.Male => MaleName ?? Name,
            _ => Name,
        };

        return Loc.GetString(stringId);
    }
}
