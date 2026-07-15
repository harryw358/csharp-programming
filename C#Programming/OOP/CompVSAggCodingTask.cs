using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Employee
    {
        private String name;
        private Address address;
        private InsuranceInfo insurance; // may or may not   


        public Employee(String name, String street, String city, String state, String postalCode)
        {
            this.name = name;
            this.address = new Address();
            address.setCity(city);
            address.setState(state);
            address.setPostalCode(postalCode);
            address.setStreet(street);
        }
        public String getName()
        {
            return name;
        }
        public void setName(String name)
        {
            this.name = name;
        }
        public Address getAddress()
        {
            return address;
        }
        public void setAddress(Address address)
        {
            this.address = address;
        }
        public InsuranceInfo getInsurance()
        {
            return insurance;
        }
        public void setInsurance(InsuranceInfo insurance)
        {
            this.insurance = insurance;
        }

        public String toString()
        {
            StringBuilder retValue = new StringBuilder();
            retValue.Append(name).Append(" ")
                .Append(address.getStreet()).Append(" ")
                .Append(address.getCity()).Append(" ")
                .Append(address.getState()).Append(" ");

            if (insurance != null) retValue.Append(insurance.getPolicyId()).Append(" ")
                .Append(insurance.getPolicyName());

            return retValue.ToString();

        }
    }

    public class Address
    {
        private String street;
        private String city;
        private String state;
        private String postalCode;

        public String getStreet()
        {
            return street;
        }
        public void setStreet(String street)
        {
            this.street = street;
        }
        public String getCity()
        {
            return city;
        }
        public void setCity(String city)
        {
            this.city = city;
        }
        public String getState()
        {
            return state;
        }
        public void setState(String state)
        {
            this.state = state;
        }
        public String getPostalCode()
        {
            return postalCode;
        }
        public void setPostalCode(String postalCode)
        {
            this.postalCode = postalCode;
        }
    }


    public class InsuranceInfo
    {
        private String policyName;
        private String policyId;

        public InsuranceInfo(string PolicyName, string PolicyID)
        {
            this.policyName = PolicyName;
            this.policyId = PolicyID;
        }

        public String getPolicyName()
        {
            return policyName;
        }
        public void setPolicyName(String policyName)
        {
            this.policyName = policyName;
        }
        public String getPolicyId()
        {
            return policyId;
        }
        public void setPolicyId(String policyId)
        {
            this.policyId = policyId;
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            //1 Create a new object of employee identified as employee1 (n.b. every instance of employee requires an instance of address made within the employee class)

            Employee employee1 = new Employee("Mick", "Close Street", "Wombwell", "South Yorkshire", "S70 0ZL");

            //2 Create a second new object of employee identified as employee2 (n.b. an instance of employee does not require an instance of InsuranceInfo)

            Employee employee2 = new Employee("Sam", "Cliff Lane", "Barnsley", "North Yorkshire", "S42 D2L");

            //3 Using Console.Writeline output the details of the employee1 using the .toString method in the employee class (n.b. note that no insurance details are displayed)

            Console.WriteLine($"Name: {employee1.Name}\nAddress: {employee1.toString()}");

            //4 Create an object called InsurancePolicy1 of the class insuranceInfo ("Medical Insurance, "1234");

            InsuranceInfo InsurancePolicy1 = new InsuranceInfo("Medical Insurance", "1234");

            //5 Assign the instance InsurancePolicy1 to employee1 using the .setInsurance method in the employee class

            employee1.setInsurance(InsurancePolicy1);

            //6 Using Console.Writeline output the details of the employee1 using the .toString method in the employee class (n.b you should now see that employee1 has an insurance policy)

            Console.WriteLine($"Name: {employee1.Name}\nAddress: {employee1.toString()});

            //7 Using Console.Writeline output the details of the employee2 using the .toString method in the employee class (n.b. note that no insurance details are displayed)

            Console.WriteLine($"Name: {employee2.Name}\nAddress: {employee2.toString()}");

            //8 Destroy the instance of employee1 by creating a new blank instance of employee (employee1 = new employee(" ", " ", " ", " ", " ");) 

            employee1 = new Employee(" ", " ", " ", " ", " ");

            //9 Can you still return details of the InsurancePolicy1? Can you return details of the orginal employee1's address/name? What is your conclusion here?
            Console.ReadKey();
        }
    }
}


