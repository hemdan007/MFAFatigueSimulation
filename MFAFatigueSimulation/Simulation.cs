using System;
using System.Collections.Generic;

namespace MFAFatigueSimulation
{
    internal class Simulation
    {
        public void Start()
        {
            Console.WriteLine("================================");
            Console.WriteLine(" MFA Fatigue Attack Simulation");
            Console.WriteLine("================================");

            Console.WriteLine();
            Console.WriteLine("Choose a scenario:");
            Console.WriteLine("1. Normal Push Authentication");
            Console.WriteLine("2. Push Authentication with Rate Limiting");
            Console.WriteLine("3. Push Authentication with Number Matching");
            Console.WriteLine("0. Exit");

            Console.WriteLine();
            Console.Write("Your choice: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    RunNormalPushAttack();
                    break;

                case "2":
                    RunRateLimiting();
                    break;

                case "3":
                    RunNumberMatching();
                    break;

                case "0":
                    Console.WriteLine("Program terminated.");
                    break;

                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
        }

        private void RunNormalPushAttack()
        {
            Console.WriteLine();
            Console.WriteLine("=== Normal Push Authentication ===");
            Console.WriteLine();
            Console.WriteLine("1. Legitimate Login");
            Console.WriteLine("2. MFA Fatigue Attack");
            Console.WriteLine();
            Console.Write("Your choice: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    RunLegitimateLogin();
                    break;

                case "2":
                    RunMFAFatigueAttack();
                    break;

                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
        }

        private void RunLegitimateLogin()
        {
            Console.WriteLine();
            Console.WriteLine("=== Legitimate Login ===");

            MFARequest request = new MFARequest
            {
                RequestId = 1,
                IsLegitimate = true,
                IsApproved = false,
                MatchingNumber = 0
            };

            Console.WriteLine();
            Console.WriteLine("You started a login attempt.");
            Console.WriteLine("An MFA request was sent to your phone.");

            string choice;

            // Ask the user to approve or reject the request
            do
            {
                Console.Write("Approve or Reject? (A/R): ");
                choice = Console.ReadLine().ToUpper();

                if (choice != "A" && choice != "R")
                {
                    Console.WriteLine("Invalid choice. Please enter A or R.");
                }

            } while (choice != "A" && choice != "R");

            // Process the user's response
            if (choice == "A")
            {
                request.IsApproved = true;
                Console.WriteLine("User approved the request.");
            }
            else
            {
                request.IsApproved = false;
                Console.WriteLine("User rejected the request.");
            }

            // Display the results
            Console.WriteLine();
            Console.WriteLine("=== Results ===");
            Console.WriteLine("Total MFA requests: 1");

            if (request.IsApproved)
            {
                Console.WriteLine("Login successful.");
                Console.WriteLine("The legitimate user gained access.");
            }
            else
            {
                Console.WriteLine("Login failed.");
                Console.WriteLine("The legitimate user was denied access.");
            }
        }

        private void RunMFAFatigueAttack()
        {
            Console.WriteLine();
            Console.WriteLine("=== MFA Fatigue Attack ===");
            Console.WriteLine();

            List<MFARequest> requests = new List<MFARequest>();

            bool loginSuccessful = false;
            int requestId = 1;
            int maxRequests = 10;

            // Simulate repeated MFA requests
            while (requestId <= maxRequests && !loginSuccessful)
            {
                MFARequest request = new MFARequest
                {
                    RequestId = requestId,
                    IsLegitimate = false,
                    IsApproved = false,
                    MatchingNumber = 0
                };

                Console.WriteLine($"MFA Request {request.RequestId}");

                string choice;

                // Ask the user to approve or reject the request
                do
                {
                    Console.Write("Approve or Reject? (A/R): ");
                    choice = Console.ReadLine().ToUpper();

                    if (choice != "A" && choice != "R")
                    {
                        Console.WriteLine("Invalid choice. Please enter A or R.");
                    }

                } while (choice != "A" && choice != "R");

                // Process the user's response
                if (choice == "A")
                {
                    request.IsApproved = true;
                    loginSuccessful = true;

                    Console.WriteLine("User approved the request.");
                }
                else
                {
                    Console.WriteLine("User rejected the request.");
                }

                // Store the request
                requests.Add(request);

                Console.WriteLine();

                requestId++;
            }

            // Display the simulation results
            Console.WriteLine("=== Results ===");
            Console.WriteLine($"Total MFA requests: {requests.Count}");

            int approvedRequests = 0;
            int rejectedRequests = 0;

            // Count approved and rejected requests
            foreach (MFARequest request in requests)
            {
                if (request.IsApproved)
                {
                    approvedRequests++;
                }
                else
                {
                    rejectedRequests++;
                }
            }

            Console.WriteLine($"Approved requests: {approvedRequests}");
            Console.WriteLine($"Rejected requests: {rejectedRequests}");

            if (loginSuccessful)
            {
                Console.WriteLine("Login successful.");
                Console.WriteLine("The attacker gained access.");
            }
            else
            {
                Console.WriteLine("Login failed.");
                Console.WriteLine("The attacker was blocked.");
            }
        }

        private void RunRateLimiting()
        {
            Console.WriteLine();
            Console.WriteLine("=== Rate Limiting ===");
            Console.WriteLine();
            Console.WriteLine("1. Legitimate Login");
            Console.WriteLine("2. MFA Fatigue Attack");
            Console.WriteLine();
            Console.Write("Your choice: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    RunRateLimitingLegitimateLogin();
                    break;

                case "2":
                    RunRateLimitingAttack();
                    break;

                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
        }

        private void RunRateLimitingLegitimateLogin()
        {
            Console.WriteLine();
            Console.WriteLine("=== Legitimate Login ===");

            MFARequest request = new MFARequest
            {
                RequestId = 1,
                IsLegitimate = true,
                IsApproved = false,
                MatchingNumber = 0
            };

            Console.WriteLine();
            Console.WriteLine("You started a login attempt.");
            Console.WriteLine("An MFA request was sent to your phone.");

            string choice;

            // Ask the user to approve or reject the request
            do
            {
                Console.Write("Approve or Reject? (A/R): ");
                choice = Console.ReadLine().ToUpper();

                if (choice != "A" && choice != "R")
                {
                    Console.WriteLine("Invalid choice. Please enter A or R.");
                }

            } while (choice != "A" && choice != "R");

            // Process the user's response
            if (choice == "A")
            {
                request.IsApproved = true;
                Console.WriteLine("User approved the request.");
            }
            else
            {
                request.IsApproved = false;
                Console.WriteLine("User rejected the request.");
            }

            // Display the results
            Console.WriteLine();
            Console.WriteLine("=== Results ===");
            Console.WriteLine("Total MFA requests: 1");

            if (request.IsApproved)
            {
                Console.WriteLine("Login successful.");
                Console.WriteLine("The legitimate user gained access.");
            }
            else
            {
                Console.WriteLine("Login failed.");
                Console.WriteLine("The legitimate user was denied access.");
            }
        }

        private void RunRateLimitingAttack()
        {
            Console.WriteLine();
            Console.WriteLine("=== MFA Fatigue Attack with Rate Limiting ===");
            Console.WriteLine();

            List<MFARequest> requests = new List<MFARequest>();

            bool loginSuccessful = false;
            int requestId = 1;
            int maxRequests = 3;

            // Simulate MFA requests with a limit
            while (requestId <= maxRequests && !loginSuccessful)
            {
                MFARequest request = new MFARequest
                {
                    RequestId = requestId,
                    IsLegitimate = false,
                    IsApproved = false,
                    MatchingNumber = 0
                };

                Console.WriteLine($"MFA Request {request.RequestId}");

                string choice;

                // Ask the user to approve or reject the request
                do
                {
                    Console.Write("Approve or Reject? (A/R): ");
                    choice = Console.ReadLine().ToUpper();

                    if (choice != "A" && choice != "R")
                    {
                        Console.WriteLine("Invalid choice. Please enter A or R.");
                    }

                } while (choice != "A" && choice != "R");

                // Process the user's response
                if (choice == "A")
                {
                    request.IsApproved = true;
                    loginSuccessful = true;

                    Console.WriteLine("User approved the request.");
                }
                else
                {
                    Console.WriteLine("User rejected the request.");
                }

                // Store the request
                requests.Add(request);

                Console.WriteLine();

                requestId++;

            }

            // Check if the request limit was reached
            if (!loginSuccessful && requests.Count == maxRequests)
            {
                Console.WriteLine("Rate limit reached.");
                Console.WriteLine("Further MFA requests are blocked.");
            }


            // Display the simulation results
            Console.WriteLine("=== Results ===");
            Console.WriteLine($"Total MFA requests: {requests.Count}");

            int approvedRequests = 0;
            int rejectedRequests = 0;

            // Count approved and rejected requests
            foreach (MFARequest request in requests)
            {
                if (request.IsApproved)
                {
                    approvedRequests++;
                }
                else
                {
                    rejectedRequests++;
                }
            }

            Console.WriteLine($"Approved requests: {approvedRequests}");
            Console.WriteLine($"Rejected requests: {rejectedRequests}");

            if (loginSuccessful)
            {
                Console.WriteLine("Login successful.");
                Console.WriteLine("The attacker gained access.");
            }
            else
            {
                Console.WriteLine("Login failed.");
                Console.WriteLine("Rate Limiting blocked further requests.");
            }
        }

        private void RunNumberMatching()
        {
            Console.WriteLine();
            Console.WriteLine("=== Number Matching ===");
            Console.WriteLine();
            Console.WriteLine("1. Legitimate Login");
            Console.WriteLine("2. MFA Fatigue Attack");
            Console.WriteLine();
            Console.Write("Your choice: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    RunNumberMatchingLegitimateLogin();
                    break;

                case "2":
                    RunNumberMatchingAttack();
                    break;

                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
        }

        private void RunNumberMatchingLegitimateLogin()
        {
            Console.WriteLine();
            Console.WriteLine("=== Legitimate Login with Number Matching ===");
            Console.WriteLine();

            Random random = new Random();
            int matchingNumber = random.Next(10, 100);

            MFARequest request = new MFARequest
            {
                RequestId = 1,
                IsLegitimate = true,
                IsApproved = false,
                MatchingNumber = matchingNumber
            };

            Console.WriteLine("You started a login attempt.");
            Console.WriteLine("An MFA request was sent to your phone.");
            Console.WriteLine();
            Console.WriteLine($"Number displayed on the login screen: {request.MatchingNumber}");
            Console.WriteLine();

            int enteredNumber;

            // Ask the user to enter the matching number
            do
            {
                Console.Write("Enter the matching number: ");

                string input = Console.ReadLine();

                if (!int.TryParse(input, out enteredNumber) || enteredNumber < 10 || enteredNumber > 99)
                {
                    Console.WriteLine("Invalid input. Please enter a number between 10 and 99.");
                    enteredNumber = -1;
                }
            } while (enteredNumber < 10 || enteredNumber > 99);

            // Check if the entered number matches
            if (enteredNumber == request.MatchingNumber)
            {
                request.IsApproved = true;
                Console.WriteLine("Number matched.");
                Console.WriteLine("User approved the request.");
            }
            else
            {
                request.IsApproved = false;
                Console.WriteLine("Number did not match.");
                Console.WriteLine("User rejected the request.");
            }

            // Display the results
            Console.WriteLine();
            Console.WriteLine("=== Results ===");
            Console.WriteLine("Total MFA requests: 1");

            if (request.IsApproved)
            {
                Console.WriteLine("Login successful.");
                Console.WriteLine("The legitimate user gained access.");
            }
            else
            {
                Console.WriteLine("Login failed.");
                Console.WriteLine("The legitimate user was denied access.");
            }
        }

        private void RunNumberMatchingAttack()
        {
            Console.WriteLine();
            Console.WriteLine("=== MFA Fatigue Attack with Number Matching ===");
            Console.WriteLine();

            List<MFARequest> requests = new List<MFARequest>();

            bool loginSuccessful = false;
            int requestId = 1;
            int failedRequestsBeforeSocialEngineering = 3;

            Random random = new Random();

            // Simulate the first three MFA requests
            while (requestId <= failedRequestsBeforeSocialEngineering && !loginSuccessful)
            {
                int matchingNumber = random.Next(10, 100);

                MFARequest request = new MFARequest
                {
                    RequestId = requestId,
                    IsLegitimate = false,
                    IsApproved = false,
                    MatchingNumber = matchingNumber
                };

                Console.WriteLine($"MFA Request {request.RequestId}");
                Console.WriteLine($"Number displayed on the login screen: {request.MatchingNumber}");
                Console.WriteLine();
                Console.WriteLine("What would you like to do?");
                Console.WriteLine("1. Enter matching number");
                Console.WriteLine("2. Reject request");
                Console.WriteLine();

                string choice;

                // Ask the user what to do
                do
                {
                    Console.Write("Your choice: ");
                    choice = Console.ReadLine();

                    if (choice != "1" && choice != "2")
                    {
                        Console.WriteLine("Invalid choice. Please enter 1 or 2.");
                    }

                } while (choice != "1" && choice != "2");

                // Process the user's choice
                if (choice == "1")
                {
                    int enteredNumber;

                    // Ask the user to enter the matching number
                    do
                    {
                        Console.Write("Enter the matching number: ");

                        string input = Console.ReadLine();

                        if (!int.TryParse(input, out enteredNumber) || enteredNumber < 10 || enteredNumber > 99)
                        {
                            Console.WriteLine("Invalid input. Please enter a number between 10 and 99.");
                            enteredNumber = -1;
                        }

                    } while (enteredNumber < 10 || enteredNumber > 99);

                    // Check if the entered number matches
                    if (enteredNumber == request.MatchingNumber)
                    {
                        request.IsApproved = true;
                        loginSuccessful = true;

                        Console.WriteLine("Number matched.");
                        Console.WriteLine("User approved the request.");
                    }
                    else
                    {
                        Console.WriteLine("Number did not match.");
                        Console.WriteLine("User rejected the request.");
                    }
                }
                else
                {
                    Console.WriteLine("User rejected the request.");
                }

                // Store the request
                requests.Add(request);

                Console.WriteLine();

                requestId++;
            }

            // Simulate social engineering after three failed requests
            if (!loginSuccessful && requests.Count == failedRequestsBeforeSocialEngineering)
            {
                Console.WriteLine("=== Social Engineering Attempt ===");
                Console.WriteLine();
                Console.WriteLine("IT Support Message:");
                Console.WriteLine("We detected repeated login attempts on your account.");
                Console.WriteLine("To verify your identity, please enter the number we provide.");
                Console.WriteLine();

                int matchingNumber = random.Next(10, 100);

                MFARequest request = new MFARequest
                {
                    RequestId = requestId,
                    IsLegitimate = false,
                    IsApproved = false,
                    MatchingNumber = matchingNumber
                };

                Console.WriteLine($"IT Support provides the number: {request.MatchingNumber}");
                Console.WriteLine();
                Console.WriteLine("What would you like to do?");
                Console.WriteLine("1. Enter matching number");
                Console.WriteLine("2. Reject request");
                Console.WriteLine();

                string choice;

                // Ask the user how to respond to the message
                do
                {
                    Console.Write("Your choice: ");
                    choice = Console.ReadLine();

                    if (choice != "1" && choice != "2")
                    {
                        Console.WriteLine("Invalid choice. Please enter 1 or 2.");
                    }

                } while (choice != "1" && choice != "2");

                // Process the user's choice
                if (choice == "1")
                {
                    int enteredNumber;

                    // Ask the user to enter the number provided by IT Support
                    do
                    {
                        Console.Write("Enter the number provided by IT Support: ");

                        string input = Console.ReadLine();

                        if (!int.TryParse(input, out enteredNumber) || enteredNumber < 10 || enteredNumber > 99)
                        {
                            Console.WriteLine("Invalid input. Please enter a number between 10 and 99.");
                            enteredNumber = -1;
                        }

                    } while (enteredNumber < 10 || enteredNumber > 99);

                    // Check if the entered number matches
                    if (enteredNumber == request.MatchingNumber)
                    {
                        request.IsApproved = true;
                        loginSuccessful = true;

                        Console.WriteLine("Number matched.");
                        Console.WriteLine("User trusted the message.");
                        Console.WriteLine("User approved the request.");
                    }
                    else
                    {
                        Console.WriteLine("Number did not match.");
                        Console.WriteLine("User rejected the request.");
                    }
                }
                else
                {
                    Console.WriteLine("User did not trust the message.");
                    Console.WriteLine("User rejected the request.");
                }

                // Store the request
                requests.Add(request);

                Console.WriteLine();
            }

            // Display the simulation results
            Console.WriteLine("=== Results ===");
            Console.WriteLine($"Total MFA requests: {requests.Count}");

            int approvedRequests = 0;
            int rejectedRequests = 0;

            // Count approved and rejected requests
            foreach (MFARequest request in requests)
            {
                if (request.IsApproved)
                {
                    approvedRequests++;
                }
                else
                {
                    rejectedRequests++;
                }
            }

            Console.WriteLine($"Approved requests: {approvedRequests}");
            Console.WriteLine($"Rejected requests: {rejectedRequests}");

            if (loginSuccessful)
            {
                Console.WriteLine("Login successful.");
                Console.WriteLine("The attacker gained access.");
            }
            else
            {
                Console.WriteLine("Login failed.");
                Console.WriteLine("The attacker was blocked.");
            }
        }
    }
}