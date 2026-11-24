# MFA Fatigue Attack Simulation 

## About the Project

## Academic Project

This project was developed as part of a semester project at Zealand – Academy of Technologies and Business.

The project focuses on MFA fatigue attacks and investigates how security measures such as Rate Limiting and Number Matching can help protect users against repeated authentication requests.
This project is a C# Console Application that simulates MFA (Multi-Factor Authentication) fatigue attacks and demonstrates how different security measures can help protect users.

The purpose of the simulation is to compare normal Push Authentication with two defensive mechanisms:

- Rate Limiting
- Number Matching

The project also includes a simple Social Engineering scenario to demonstrate how attackers may try to trick users into approving authentication requests.

## Scenarios

### 1. Normal Push Authentication
Simulates a normal MFA push notification without additional security controls.

The user can:
- Approve a legitimate login request.
- Reject a legitimate login request.
- Experience repeated MFA requests during a simulated MFA fatigue attack.
- Approve or reject each request manually.

### 2. Push Authentication with Rate Limiting
Simulates MFA authentication with a limit on the number of requests.

In this simulation:
- A maximum of 3 MFA requests is allowed.
- If all 3 requests are rejected, further requests are blocked.
- The user can still approve a request before reaching the limit.

### 3. Push Authentication with Number Matching
Simulates MFA authentication using number matching.

The user must enter the number displayed on the login screen to approve the authentication request.

This scenario includes:
- Legitimate login using number matching.
- MFA fatigue attack using number matching.
- A simulated Social Engineering attempt where the attacker impersonates IT Support and tries to convince the user to enter a matching number.

## Technologies

- C#
- .NET
- Console Application

## How to Run

1. Clone the repository:

```bash
git clone <repository-url>
```

2. Open the project in Visual Studio.

3. Build the project.

4. Run the application.

5. Select a scenario from the main menu.

## Simulation Assumptions

- The attacker is assumed to already know the user's password.
- No real MFA service or mobile device is used.
- All MFA requests are simulated locally.
- User responses are entered manually through the console.
- Rate Limiting allows a maximum of 3 requests per simulation.
- Number Matching uses randomly generated two-digit numbers.
- Social Engineering is simulated through a fake IT Support message.
- The simulation does not measure real human behaviour.

## Project Purpose

The project is part of an academic synopsis investigating how users can be protected against MFA fatigue attacks.

The simulation is used to demonstrate and compare the effectiveness and limitations of different security controls.

## Disclaimer

This project is created for educational purposes only. It does not perform real authentication, send MFA notifications, or attack real accounts.
