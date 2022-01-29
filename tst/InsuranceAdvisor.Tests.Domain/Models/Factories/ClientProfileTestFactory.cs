using InsuranceAdvisor.Domain.Models;
using System.Collections.Generic;

namespace InsuranceAdvisor.Tests.Domain.Models.Factories
{
    public static class ClientProfileTestFactory
    {
        public static ClientProfile CreateClientProfile(int age,
                                                        int dependents,
                                                        HouseProfile? house,
                                                        decimal income,
                                                        MaritalStatus maritalStatus,
                                                        List<int> riskQuestions,
                                                        VehicleProfile? vehicle)
            => new ClientProfile(age,
                                 dependents,
                                 house,
                                 income,
                                 maritalStatus,
                                 riskQuestions,
                                 vehicle);

        public static ClientProfile CreateValidClientProfile()
            => CreateClientProfile(age: 0,
                                   dependents: 0,
                                   house: null,
                                   income: 0,
                                   maritalStatus: MaritalStatus.Single,
                                   riskQuestions: new List<int> { 0, 0, 0 },
                                   vehicle: null);

        public static ClientProfile CreateValidClientProfileWithAge(int age)
            => CreateClientProfile(age: age,
                                   dependents: 0,
                                   house: null,
                                   income: 0,
                                   maritalStatus: MaritalStatus.Single,
                                   riskQuestions: new List<int> { 0, 0, 0 },
                                   vehicle: null);

        public static ClientProfile CreateValidClientProfileWithDependents(int dependents)
            => CreateClientProfile(age: 0,
                                   dependents: dependents,
                                   house: null,
                                   income: 0,
                                   maritalStatus: MaritalStatus.Single,
                                   riskQuestions: new List<int> { 0, 0, 0 },
                                   vehicle: null);

        public static ClientProfile CreateValidClientProfileWithHouse(HouseProfile house)
            => CreateClientProfile(age: 0,
                                   dependents: 0,
                                   house: house,
                                   income: 0,
                                   maritalStatus: MaritalStatus.Single,
                                   riskQuestions: new List<int> { 0, 0, 0 },
                                   vehicle: null);

        public static ClientProfile CreateValidClientProfileWithIncome(int income)
            => CreateClientProfile(age: 0,
                                   dependents: 0,
                                   house: null,
                                   income: income,
                                   maritalStatus: MaritalStatus.Single,
                                   riskQuestions: new List<int> { 0, 0, 0 },
                                   vehicle: null);

        public static ClientProfile CreateValidClientProfileWithMaritalStatus(MaritalStatus maritalStatus)
            => CreateClientProfile(age: 0,
                                   dependents: 0,
                                   house: null,
                                   income: 0,
                                   maritalStatus: maritalStatus,
                                   riskQuestions: new List<int> { 0, 0, 0 },
                                   vehicle: null);

        public static ClientProfile CreateValidClientProfileWithRiskQuestions(List<int> riskQuestions)
            => CreateClientProfile(age: 0,
                                   dependents: 0,
                                   house: null,
                                   income: 0,
                                   maritalStatus: MaritalStatus.Single,
                                   riskQuestions: riskQuestions,
                                   vehicle: null);

        public static ClientProfile CreateValidClientProfileWithVehicle(VehicleProfile vehicle)
            => CreateClientProfile(age: 0,
                                   dependents: 0,
                                   house: null,
                                   income: 0,
                                   maritalStatus: MaritalStatus.Single,
                                   riskQuestions: new List<int> { 0, 0, 0 },
                                   vehicle: vehicle);
    }
}
