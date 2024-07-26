using SFSAdv.Domain.Utilities;

namespace SFSAdv.Domain.Aggregates.UserAggregate.Entities;

public partial class User
{
    private User()
    {
    }

    public static User CreateWithDefaults(string name)
    {
        return Create(Guid.NewGuid(), name);
    }

    public static User Create(Guid id, string name)
    {
        Guard.AgainstEmpty(id, nameof(id));
        Guard.AgainstNullOrEmpty(name, nameof(name));

        return new User
        {
            Id = id,
            Name = name
        };
    }
}
