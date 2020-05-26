namespace Tapas.Data
{
    using Microsoft.AspNetCore.Identity;
    using Tapas.Common;

    public class LocalizedIdentityErrorDescriber : IdentityErrorDescriber
    {
        public override IdentityError DuplicateEmail(string email)
        {
            return new IdentityError
            {
                Code = nameof(this.DuplicateEmail),
                Description = string.Format(LocalizedIdentityErrorMessages.DuplicateEmail, email),
            };
        }

        public override IdentityError DuplicateUserName(string userName)
        {
            return new IdentityError
            {
                Code = nameof(this.DuplicateUserName),
                Description = string.Format(LocalizedIdentityErrorMessages.DuplicateUserName, userName),
            };
        }

        public override IdentityError InvalidEmail(string email)
        {
            return new IdentityError
            {
                Code = nameof(this.InvalidEmail),
                Description = string.Format(LocalizedIdentityErrorMessages.InvalidEmail, email),
            };
        }

        public override IdentityError DuplicateRoleName(string role)
        {
            return new IdentityError
            {
                Code = nameof(this.DuplicateRoleName),
                Description = string.Format(LocalizedIdentityErrorMessages.DuplicateRoleName, role),
            };
        }

        public override IdentityError InvalidRoleName(string role)
        {
            return new IdentityError
            {
                Code = nameof(this.InvalidRoleName),
                Description = string.Format(LocalizedIdentityErrorMessages.InvalidRoleName, role),
            };
        }

        public override IdentityError InvalidToken()
        {
            return new IdentityError
            {
                Code = nameof(this.InvalidToken),
                Description = LocalizedIdentityErrorMessages.InvalidToken,
            };
        }

        public override IdentityError InvalidUserName(string userName)
        {
            return new IdentityError
            {
                Code = nameof(this.InvalidUserName),
                Description = string.Format(LocalizedIdentityErrorMessages.InvalidUserName, userName),
            };
        }

        public override IdentityError LoginAlreadyAssociated()
        {
            return new IdentityError
            {
                Code = nameof(this.LoginAlreadyAssociated),
                Description = LocalizedIdentityErrorMessages.LoginAlreadyAssociated,
            };
        }

        public override IdentityError PasswordMismatch()
        {
            return new IdentityError
            {
                Code = nameof(this.PasswordMismatch),
                Description = LocalizedIdentityErrorMessages.PasswordMismatch,
            };
        }

        public override IdentityError PasswordRequiresDigit()
        {
            return new IdentityError
            {
                Code = nameof(this.PasswordRequiresDigit),
                Description = LocalizedIdentityErrorMessages.PasswordRequiresDigit,
            };
        }

        public override IdentityError PasswordRequiresLower()
        {
            return new IdentityError
            {
                Code = nameof(this.PasswordRequiresLower),
                Description = LocalizedIdentityErrorMessages.PasswordRequiresLower,
            };
        }

        public override IdentityError PasswordRequiresNonAlphanumeric()
        {
            return new IdentityError
            {
                Code = nameof(this.PasswordRequiresNonAlphanumeric),
                Description = LocalizedIdentityErrorMessages.PasswordRequiresNonAlphanumeric,
            };
        }

        public override IdentityError PasswordRequiresUniqueChars(int uniqueChars)
        {
            return new IdentityError
            {
                Code = nameof(this.PasswordRequiresUniqueChars),
                Description = string.Format(LocalizedIdentityErrorMessages.PasswordRequiresUniqueChars, uniqueChars),
            };
        }

        public override IdentityError PasswordRequiresUpper()
        {
            return new IdentityError
            {
                Code = nameof(this.PasswordRequiresUpper),
                Description = LocalizedIdentityErrorMessages.PasswordRequiresUpper,
            };
        }

        public override IdentityError PasswordTooShort(int length)
        {
            return new IdentityError
            {
                Code = nameof(this.PasswordTooShort),
                Description = string.Format(LocalizedIdentityErrorMessages.PasswordTooShort, length),
            };
        }

        public override IdentityError UserAlreadyHasPassword()
        {
            return new IdentityError
            {
                Code = nameof(this.UserAlreadyHasPassword),
                Description = LocalizedIdentityErrorMessages.UserAlreadyHasPassword,
            };
        }

        public override IdentityError UserAlreadyInRole(string role)
        {
            return new IdentityError
            {
                Code = nameof(this.UserAlreadyInRole),
                Description = string.Format(LocalizedIdentityErrorMessages.UserAlreadyInRole, role),
            };
        }

        public override IdentityError UserNotInRole(string role)
        {
            return new IdentityError
            {
                Code = nameof(this.UserNotInRole),
                Description = string.Format(LocalizedIdentityErrorMessages.UserNotInRole, role),
            };
        }

        public override IdentityError UserLockoutNotEnabled()
        {
            return new IdentityError
            {
                Code = nameof(this.UserLockoutNotEnabled),
                Description = LocalizedIdentityErrorMessages.UserLockoutNotEnabled,
            };
        }

        public override IdentityError RecoveryCodeRedemptionFailed()
        {
            return new IdentityError
            {
                Code = nameof(this.RecoveryCodeRedemptionFailed),
                Description = LocalizedIdentityErrorMessages.RecoveryCodeRedemptionFailed,
            };
        }

        public override IdentityError ConcurrencyFailure()
        {
            return new IdentityError
            {
                Code = nameof(this.ConcurrencyFailure),
                Description = LocalizedIdentityErrorMessages.ConcurrencyFailure,
            };
        }

        public override IdentityError DefaultError()
        {
            return new IdentityError
            {
                Code = nameof(this.DefaultError),
                Description = LocalizedIdentityErrorMessages.DefaultIdentityError,
            };
        }
    }
}
