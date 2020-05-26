namespace Tapas.Common
{
    public class LocalizedIdentityErrorMessages
    {
        public const string DuplicateEmail = "Имейлът {0} вече е зает.";
        public const string DuplicateUserName = "Потребителското име {0} вече е заето.";
        public const string InvalidEmail = "Имейлът {0} е невалиден.";
        public const string DuplicateRoleName = "Името на ролята {0} вече е заето.";
        public const string InvalidRoleName = "Името на ролята {0} е невалидно.";
        public const string InvalidToken = "Невалиден токен.";
        public const string InvalidUserName = "Потребителското име {0} е невалидно, може да съдържа само букви или цифри.";
        public const string LoginAlreadyAssociated = "Потребител с това име вече съществува.";
        public const string PasswordMismatch = "Грешна парола.";
        public const string PasswordRequiresDigit = "Паролата трябва да има поне една цифра.";
        public const string PasswordRequiresLower = "Паролата трябва да има поне една малка буква.";
        public const string PasswordRequiresNonAlphanumeric = "Паролата трябва да има поне един знак който не е буква нито цифра.";
        public const string PasswordRequiresUniqueChars = "Паролата трябеа да има поне един уникален знак.";
        public const string PasswordRequiresUpper = "Паролата трябва да има поне една главна буква.";
        public const string PasswordTooShort = "Паролата трябва да съдържа най-малко {0} знака.";
        public const string UserAlreadyHasPassword = "Потребителят вече има зададена парола.";
        public const string UserAlreadyInRole = "Потребител, вече е в роля {0}.";
        public const string UserNotInRole = "Потребителят не е в роля {0}.";
        public const string UserLockoutNotEnabled = "Заключването не е активирано за този потребител.";
        public const string RecoveryCodeRedemptionFailed = "Възстановяването на кода за възстановяване не бе успешно.";
        public const string ConcurrencyFailure = "Обектът е променен.";
        public const string DefaultIdentityError = "Възникна неизвестна грешка.";
    }
}
