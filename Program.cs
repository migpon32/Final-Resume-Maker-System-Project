using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

class ResumeMaker
{
    static void Main()
    {
        Console.WriteLine("Welcome to Resume Maker!");
        Console.WriteLine("----------------------------");

        string lastName = "";
        string firstName = "";
        string middleName = "";
        string phoneNumber = "";
        string address = "";
        string emailAddress = "";
        string religion = "";
        string dateOfBirth = "";
        int age = 0;
        string education = "";
        string maritalStatus = "";
        string workExperience = "";
        string skills = "";

        bool lastNameEntered = false;
        bool firstNameEntered = false;
        bool middleNameEntered = false;
        bool phoneNumberEntered = false;
        bool addressEntered = false;
        bool emailAddressEntered = false;
        bool religionEntered = false;
        bool dateOfBirthEntered = false;
        bool educationEntered = false;
        bool maritalStatusEntered = false;
        bool workExperienceEntered = false;
        bool skillsEntered = false;

        bool informationCorrect = false;

        while (!informationCorrect)
        {
            // Get user input for last name
            if (!lastNameEntered)
            {
                lastName = GetInput("Enter your Last Name: ");
                if (!IsValidNamePart(lastName, "Last Name", out string lastNameErrorMessage))
                {
                    Console.WriteLine($"\nInvalid Last Name. {lastNameErrorMessage}");
                    continue;
                }
                lastNameEntered = true;
            }

            // Get user input for first name
            if (!firstNameEntered)
            {
                firstName = GetInput("Enter your First Name: ");
                if (!IsValidNamePart(firstName, "First Name", out string firstNameErrorMessage))
                {
                    Console.WriteLine($"\nInvalid First Name. {firstNameErrorMessage}");
                    continue;
                }
                firstNameEntered = true;
            }

            // Get user input for middle name
            if (!middleNameEntered)
            {
                middleName = GetInput("Enter your Middle Name: ");
                if (!IsValidNamePart(middleName, "Middle Name", out string middleNameErrorMessage))
                {
                    Console.WriteLine($"\nInvalid Middle Name. {middleNameErrorMessage}");
                    continue;
                }
                middleNameEntered = true;
            }

            // Get user input for phone number
            if (!phoneNumberEntered)
            {
                phoneNumber = GetInput("Enter your Phone Number: ");
                if (!IsValidPhoneNumber(phoneNumber, out string phoneErrorMessage))
                {
                    Console.WriteLine($"\nInvalid Phone Number. {phoneErrorMessage}");
                    continue;
                }
                phoneNumberEntered = true;
            }

            // Get user input for address
            if (!addressEntered)
            {
                address = GetInput("Enter your Address: ");
                if (!IsValidAddress(address, out string addressErrorMessage))
                {
                    Console.WriteLine($"\nInvalid Address. {addressErrorMessage}");
                    continue;
                }
                addressEntered = true;
            }

            // Get user input for email address
            if (!emailAddressEntered)
            {
                emailAddress = GetInput("Enter your Email Address: ");
                if (!IsValidEmail(emailAddress, out string emailErrorMessage))
                {
                    Console.WriteLine($"\nInvalid Email Address. {emailErrorMessage}");
                    continue;
                }
                emailAddressEntered = true;
            }

            // Get user input for religion
            if (!religionEntered)
            {
                religion = GetInput("\nEnter your Religion: ");
                religionEntered = true;
            }

            // Get user input for date of birth
            if (!dateOfBirthEntered)
            {
                dateOfBirth = GetInput("Enter your Date of Birth (MM/dd/yyyy): ");
                if (!IsValidDateOfBirth(dateOfBirth, out string dateOfBirthErrorMessage, out age))
                {
                    Console.WriteLine($"\nInvalid Date of Birth: {dateOfBirthErrorMessage}");
                    continue;
                }
                dateOfBirthEntered = true;
            }

            // Get user input for educational background
            if (!educationEntered)
            {
                education = GetInput("\nEnter your Educational Background: ");
                educationEntered = true;
            }

            // Get user input for marital status
            if (!maritalStatusEntered)
            {
                maritalStatus = GetInput("Enter your Marital Status (Single or Married): ");
                if (!IsValidMaritalStatus(maritalStatus, out string maritalStatusErrorMessage))
                {
                    Console.WriteLine($"\nInvalid Marital Status: {maritalStatusErrorMessage}");
                    continue;
                }
                maritalStatusEntered = true;
            }

            // Get user input for work experience
            if (!workExperienceEntered)
            {
                workExperience = GetInput("Enter your Work Experience: ");
                if (!IsValidWorkExperience(workExperience, out string workExperienceErrorMessage))
                {
                    Console.WriteLine($"\nInvalid Work Experience: {workExperienceErrorMessage}");
                    continue;
                }
                workExperienceEntered = true;
            }

            // Get user input for skills
            if (!skillsEntered)
            {
                skills = GetInput("Enter your Skills: ");
                if (!IsValidSkills(skills, out string skillsErrorMessage))
                {
                    Console.WriteLine($"\nInvalid Skills. {skillsErrorMessage}");
                    continue;
                }
                skillsEntered = true;
            }

            // Display a summary for confirmation
                Console.Clear(); // Clears the console
                Console.WriteLine("\n=============================Resume=============================");
                Console.WriteLine($"|         |");
                Console.WriteLine($"|   1x1   |");
                Console.WriteLine($"|         |");
                Console.WriteLine($"|---------|");
                Console.WriteLine($"Full Name: {lastName}, {firstName} {middleName}");
                Console.WriteLine($"Contact Number: {phoneNumber}");
                Console.WriteLine($"Address: {address}");
                Console.WriteLine($"Email Address: {emailAddress}");
                Console.WriteLine($"Religion: {religion}");
                Console.WriteLine($"Date of Birth: {dateOfBirth}");
                Console.WriteLine($"Age: {age}");
                Console.WriteLine($"Educational Background: {education}");
                Console.WriteLine($"Marital Status: {maritalStatus}");
                Console.WriteLine($"Work Experience: {workExperience}");
                Console.WriteLine($"Skills: {skills}");
                Console.WriteLine("=============================Resume=============================");

// Ask for confirmation
Console.Write("\nIs the information correct? (yes/no): ");
string confirmation = Console.ReadLine().ToLower();


            if (confirmation == "yes")
            {
                informationCorrect = true;
            }
            else
            {
                Console.WriteLine("\nPlease provide the correct information or choose a question to edit:");

                // Display a menu of questions for the user to choose from
                Console.WriteLine("1. Last Name");
                Console.WriteLine("2. First Name");
                Console.WriteLine("3. Middle Name");
                Console.WriteLine("4. Phone Number");
                Console.WriteLine("5. Address");
                Console.WriteLine("6. Email Address");
                Console.WriteLine("7. Religion");
                Console.WriteLine("8. Date of Birth");
                Console.WriteLine("9. Educational Background");
                Console.WriteLine("10. Marital Status");
                Console.WriteLine("11. Work Experience");
                Console.WriteLine("12. Skills");

                Console.Write("Enter the number of the question to edit: ");
                string questionNumberInput = Console.ReadLine();

                // Handle the user's input for editing a specific question
                if (int.TryParse(questionNumberInput, out int questionNumber) && questionNumber >= 1 && questionNumber <= 12)
                {
                    switch (questionNumber)
                    {
                        case 1:
                            lastNameEntered = false;
                            break;
                        case 2:
                            firstNameEntered = false;
                            break;
                        case 3:
                            middleNameEntered = false;
                            break;
                        case 4:
                            phoneNumberEntered = false;
                            break;
                        case 5:
                            addressEntered = false;
                            break;
                        case 6:
                            emailAddressEntered = false;
                            break;
                        case 7:
                            religionEntered = false;
                            break;
                        case 8:
                            dateOfBirthEntered = false;
                            break;
                        case 9:
                            educationEntered = false;
                            break;
                        case 10:
                            maritalStatusEntered = false;
                            break;
                        case 11:
                            workExperienceEntered = false;
                            break;
                        case 12:
                            skillsEntered = false;
                            break;
                        default:
                            Console.WriteLine("Invalid question number.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a valid question number.");
                }
            }
        }

        // Generate resume content
     ;
        string resumeContent = $"=============================Resume=============================\n" +
                               $"|         |\n" +
                               $"|   1x1   |\n" +
                               $"|         |\n" +
                               $"|---------|\n" +
                               $"Full Name: {lastName}, {firstName} {middleName}\n" +
                               $"Contact Number: {phoneNumber}\n" +
                               $"Address: {address}\n" +
                               $"Email Address: {emailAddress}\n" +
                               $"Religion: {religion}\n" +
                               $"Date of Birth: {dateOfBirth}\n" +
                               $"Age: {age}\n" +
                               $"Educational Background:\n{education}\n" +
                               $"Marital Status: {maritalStatus}\n" +
                               $"Work Experience:\n{workExperience}\n" +
                               $"Skills: {skills}\n" +
                               "=============================Resume=============================";

        

        // Save the resume to a file
        string filePath = "resume.txt";
        File.WriteAllText(filePath, resumeContent);

        // Display generated resume content
        
        Console.WriteLine("\n=============================Resume=============================");
        Console.WriteLine("Generated Resume Content:");
        Console.WriteLine("==========================Final Output==========================");
        Console.WriteLine(resumeContent);
        Console.WriteLine("==========================Final Output==========================");

        Console.WriteLine($"\nYour resume has been created successfully!");
        Console.WriteLine($"You can find your resume in the file: {filePath}");
    }

    static string GetInput(string prompt)
    {
        Console.Write(prompt);
        return Console.ReadLine()?.Trim();
    }

    static bool IsValidPhoneNumber(string phoneNumber, out string errorMessage)
    {
        errorMessage = string.Empty;

        if (string.IsNullOrWhiteSpace(phoneNumber))
        {
            errorMessage = "Contact number cannot be empty.";
            return false;
        }

        if (phoneNumber.Length != 11 || !phoneNumber.All(char.IsDigit))
        {
            errorMessage = "Contact number must be exactly 11 digits and contain only numeric characters.";
            return false;
        }

        errorMessage = "Valid contact number.";
        return true;
    }

    static bool IsValidEmail(string emailAddress, out string errorMessage)
    {
        errorMessage = string.Empty;

        if (string.IsNullOrWhiteSpace(emailAddress))
        {
            errorMessage = "Email address cannot be empty.";
            return false;
        }

        if (!emailAddress.Contains("@"))
        {
            errorMessage = "Email address must contain '@'.";
            return false;
        }

        errorMessage = "Valid email address.";
        return true;
    }

    static bool IsValidNamePart(string namePart, string partName, out string errorMessage)
    {
        errorMessage = string.Empty;

        if (string.IsNullOrWhiteSpace(namePart))
        {
            errorMessage = $"{partName} cannot be empty.";
            return false;
        }

        if (!namePart.All(c => char.IsLetter(c) || char.IsWhiteSpace(c)))
        {
            errorMessage = $"{partName} should contain only letters.";
            return false;
        }

        errorMessage = $"Valid {partName.ToLower()}."; // Lowercased for consistency
        return true;
    }



    static bool IsValidDateOfBirth(string dateOfBirth, out string errorMessage, out int age)
    {
        errorMessage = string.Empty;
        age = 18;

        if (string.IsNullOrWhiteSpace(dateOfBirth))
        {
            errorMessage = "Date of Birth cannot be empty.";
            return false;
        }

        if (!DateTime.TryParseExact(dateOfBirth, "MM/dd/yyyy", null, System.Globalization.DateTimeStyles.None, out DateTime dob))
        {
            errorMessage = "Invalid Date of Birth format. Please use the format MM/dd/yyyy.";
            return false;
        }

        // Calculate age based on the date of birth
        age = CalculateAge(dob);

        // Check if age is within the allowed range (18 to 999 years old)
        if (age < 18 || age > 999)
        {
            errorMessage = "Age must be between 18 and 999 years old.";
            return false;
        }

        errorMessage = $"Valid Date of Birth. Age: {age}.";
        return true;
    }


    static int CalculateAge(DateTime dateOfBirth)
    {
        DateTime currentDate = DateTime.Now;
        int age = currentDate.Year - dateOfBirth.Year;

        // Adjust age if the birthday hasn't occurred yet this year
        if (currentDate.Month < dateOfBirth.Month || (currentDate.Month == dateOfBirth.Month && currentDate.Day < dateOfBirth.Day))
        {
            age--;
        }

        return age;
    }

    static bool IsValidMaritalStatus(string maritalStatus, out string errorMessage)
    {
        errorMessage = string.Empty;

        if (string.IsNullOrWhiteSpace(maritalStatus))
        {
            errorMessage = "Marital status cannot be empty.";
            return false;
        }

        // You can customize the validation rules for marital status as needed
        string[] validMaritalStatuses = { "Single", "Married" };
        if (!validMaritalStatuses.Contains(maritalStatus, StringComparer.OrdinalIgnoreCase))
        {
            errorMessage = "Invalid marital status. Please enter 'Single' or 'Married'.";
            return false;
        }

        errorMessage = "Valid marital status.";
        return true;
    }

    static bool IsValidWorkExperience(string workExperience, out string errorMessage)
    {
        errorMessage = string.Empty;

        if (string.IsNullOrWhiteSpace(workExperience))
        {
            errorMessage = "Work experience cannot be empty.";
            return false;
        }

        // Check if work experience contains only letters and spaces
        if (!workExperience.All(c => char.IsLetter(c) || char.IsWhiteSpace(c)))
        {
            errorMessage = "Work experience should contain only letters and spaces.";
            return false;
        }

        errorMessage = "Valid work experience.";
        return true;
    }
    static bool IsValidAddress(string address, out string errorMessage)
    {
        errorMessage = string.Empty;

        if (string.IsNullOrWhiteSpace(address))
        {
            errorMessage = "Address cannot be empty.";
            return false;
        }

        // Use a regular expression to check if the address contains only letters, numbers, and punctuation
        string pattern = @"^[a-zA-Z0-9\s\p{P}]+$";
        if (!Regex.IsMatch(address, pattern))
        {
            errorMessage = "Address should contain only letters, numbers, and punctuation.";
            return false;
        }

        errorMessage = "Valid address.";
        return true;
    }
    static bool IsValidSkills(string skills, out string errorMessage)
    {
        errorMessage = string.Empty;

        if (string.IsNullOrWhiteSpace(skills))
        {
            errorMessage = "Skills cannot be empty.";
            return false;
        }

        // Check if skills contain only letters, numbers, and commas
        string pattern = @"^[a-zA-Z0-9,\s]+$";
        if (!Regex.IsMatch(skills, pattern))
        {
            errorMessage = "Skills should contain only letters, numbers, and commas.";
            return false;
        }

        errorMessage = "Valid skills.";
        return true;
    }
}