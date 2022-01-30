# InsuranceAdvisor
This application is an Insurance Advisor that receives a data input and returns the suggested insurances by category.

This application was created based on [Origin Backend proposal](https://github.com/OriginFinancial/origin-backend-take-home-assignment#readme).

> Important: We put a copy of the original document at the bottom of this page as a static reference.

## Technical Decisions
The main goal on this project was to be minimalistic. We focused on keeping the code clean and uncoupled, keeping the Domain context well structured and testable. We also focused on creating a generic rules' system easly extensible. In general we followed the _Clean Code principles_.

### Table Of Rules

Based on the [original document proposal](https://github.com/OriginFinancial/origin-backend-take-home-assignment#readme) we mapped all the domain rules of the risk algorithm so we could better understand its needs.

| Rule                        |	Life       | Disability |	Home       | Auto       |
|-----------------------------|------------|------------|------------|------------|
| No income                   |	0          | Ineligible |	0          | 0          |
| No vehicle                  |	0	         | 0          | 0          | Ineligible |
| No house                    | 0	         | 0          |	Ineligible | 0          |
| Over 60 years old           | Ineligible | Ineligible |	0          | 0          |
| Under 30 years old          |	-2         | -2         |	-2         | -2         |
| Between 30 and 40 years old |	-1         | -1         | -1         | -1         |
| Income above $200k	        | -1         | -1         |	-1         | -1         |
| House is mortgaged          | 0	         | 1          | 1          | 0          |
| Has dependents              |	1	         | 1          |	0	         | 0          |
| Is married                  |	1          | -1         |	0          | 0          | 
| Vehicle has 5 or less years |	1          | 0          |	0	         | 0          |

After that we created the application architecture and the generic rules system, also applying unit tests to ensure the quality of the system.

    🎉 We are proud of the achievements done through all the development process. 🎉 - Adriano Kerber

## How to run
Two methods for running this application will be presented below, choose the one that best fits your necessity.

### 1. Containerized
Use [Docker](https://www.docker.com/) to run the application without the need of manually install the dependencies. For this you will just need to install Docker from their page [here](https://www.docker.com/get-started).

After you have installed Docker on your local machine just run the following shell command
```bash
docker-compose up -d
```
If you need to force a rebuild just use the command below instead
```bash
docker-compose up -d --build
```
Once you need to stop the application just run the line below to shutdown all containers
```bash
docker-compose down
```
When the application is running you can access the endpoint using our Postman collection [here](https://www.postman.com/adrianokerber/workspace/insuranceadvisor/collection/6297841-d1f2a6a7-6669-43b2-9c3b-8087b9d1cf6d?ctx=documentation). Just remember to set Postman's environment to **Containerized (Docker)**.
> On Postman set the environment to  **Containerized (Docker)**

> Tip: Instead of Docker if you prefer you could use [Podman](https://podman.io/). Be advised that the docker-compose is still experimental on Podman and I particularly haven't tested this feature yet.

### 2. Local setup
For this method you will need to install all the dependencies required to run the application.

Start by installing .NET SDK version 6.0.x from [here](https://dotnet.microsoft.com/en-us/download/dotnet/6.0).
Once installed just run the following command to start the application
```bash
dotnet run --project src/InsuranceAdvisor.WebApi/InsuranceAdvisor.WebApi.csproj
```
In order to access the application you can use its Swagger page [https://localhost:7012/swagger/](https://localhost:7012/swagger/) or use our Postman collection [here](https://www.postman.com/adrianokerber/workspace/insuranceadvisor/collection/6297841-d1f2a6a7-6669-43b2-9c3b-8087b9d1cf6d?ctx=documentation). Just remember to set Postman's environment to **Local (.NET SDK installed on machine)**
> On Postman set the environment to  **Local (.NET SDK installed on machine)**

To run the test cases just use
```bash
dotnet test tst/InsuranceAdvisor.Tests.Domain/
```

## 🎉 Congratulations you did it! 🎉
If you followed one of the two setup methods above then you should have the application up and running properly.

> Note: we use [gitmoji](https://gitmoji.dev/) pattern to improve commit readability on this repository

---

# <span style="color: magenta;">Below is the original description for this application development</span>
  # Origin Backend Take-Home Assignment
  Origin offers its users an insurance package personalized to their specific needs without requiring the user to understand anything about insurance. This allows Origin to act as their *de facto* insurance advisor.

  Origin determines the user’s insurance needs by asking personal & risk-related questions and gathering information about the user’s vehicle and house. Using this data, Origin determines their risk profile for **each** line of insurance and then suggests an insurance plan (`"economic"`, `"regular"`, `"responsible"`) corresponding to her risk profile.

  For this assignment, you will create a simple version of that application by coding a simple API endpoint that receives a JSON payload with the user information and returns her risk profile (JSON again) – you don’t have to worry about the frontend of the application.

  ## The input
  First, the would-be frontend of this application asks the user for her **personal information**. Then, it lets her add her **house** and **vehicle**. Finally, it asks her to answer 3 binary **risk questions**. The result produces a JSON payload, posted to the application’s API endpoint, like this example:

  ```JSON
  {
    "age": 35,
    "dependents": 2,
    "house": {"ownership_status": "owned"},
    "income": 0,
    "marital_status": "married",
    "risk_questions": [0, 1, 0],
    "vehicle": {"year": 2018}
  }
  ```

  ### User attributes
  All user attributes are required:

  - Age (an integer equal or greater than 0).
  - The number of dependents (an integer equal or greater than 0).
  - Income (an integer equal or greater than 0).
  - Marital status (`"single"` or `"married"`).
  - Risk answers (an array with 3 booleans).

  ### House
  Users can have 0 or 1 house. When they do, it has just one attribute: `ownership_status`, which can be `"owned"` or `"mortgaged"`.

  ### Vehicle
  Users can have 0 or 1 vehicle. When they do, it has just one attribute: a positive integer corresponding to the `year` it was manufactured.

  ## The risk algorithm
  The application receives the JSON payload through the API endpoint and transforms it into a *risk profile* by calculating a *risk score* for each line of insurance (life, disability, home & auto) based on the information provided by the user.

  First, it calculates the *base score* by summing the answers from the risk questions, resulting in a number ranging from 0 to 3. Then, it applies the following rules to determine a *risk score* for each line of insurance.

  1. If the user doesn’t have income, vehicles or houses, she is ineligible for disability, auto, and home insurance, respectively.
  2. If the user is over 60 years old, she is ineligible for disability and life insurance.
  3. If the user is under 30 years old, deduct 2 risk points from all lines of insurance. If she is between 30 and 40 years old, deduct 1.
  4. If her income is above $200k, deduct 1 risk point from all lines of insurance. 
  5. If the user's house is mortgaged, add 1 risk point to her home score and add 1 risk point to her disability score. 
  6. If the user has dependents, add 1 risk point to both the disability and life scores. 
  7. If the user is married, add 1 risk point to the life score and remove 1 risk point from disability. 
  8. If the user's vehicle was produced in the last 5 years, add 1 risk point to that vehicle’s score.

  This algorithm results in a final score for each line of insurance, which should be processed using the following ranges:

  - **0 and below** maps to **“economic”**.
  - **1 and 2** maps to **“regular”**.
  - **3 and above** maps to **“responsible”**.


  ## The output
  Considering the data provided above, the application should return the following JSON payload:

  ```JSON
  {
      "auto": "regular",
      "disability": "ineligible",
      "home": "economic",
      "life": "regular"
  }
  ```

  ## Criteria
  You may use any language and framework provided that you build a solid system with an emphasis on code quality, simplicity, readability, maintainability, and reliability, particularly regarding architecture and testing. We'd prefer it if you used Python, but it's just that – a preference.

  Be aware that Origin will mainly take into consideration the following evaluation criteria:
  * How clean and organized your code is;
  * If you implemented the business rules correctly;
  * How good your automated tests are (qualitative over quantitative).

  Other important notes:
  * Develop a extensible score calculation engine
  * Add to the README file: (1) instructions to run the code; (2) what were the main technical decisions you made; (3) relevant comments about your project 
  * You must use English in your code and also in your docs

  This assignment should be doable in less than one day. We expect you to learn fast, **communicate with us**, and make decisions regarding its implementation & scope to achieve the expected results on time.

  It is not necessary to build the screens a user would interact with, however, as the API is intended to power a user-facing application, we expect the implementation to be as close as possible to what would be necessary in real-life. Consider another developer would get your project/repository to evolve and implement new features from exactly where you stopped. 

