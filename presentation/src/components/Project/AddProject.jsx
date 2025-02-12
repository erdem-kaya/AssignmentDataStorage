import React, { useState, useEffect } from "react";
import axios from "axios";

const AddProject = () => {
  const [formData, setFormData] = useState({
    title: "",
    description: "",
    startDate: "",
    endDate: "",
    customerId: "",
    leadEmployeeId: "",
    statusTypeId: "",
    serviceId: "",
  });

  const [customers, setCustomers] = useState([]);
  const [employees, setEmployees] = useState([]);
  const [services, setServices] = useState([]);
  const [customerType, setCustomerType] = useState("Privat");
  const [companyName, setCompanyName] = useState("");
  const [message, setMessage] = useState("");

  useEffect(() => {
    const fetchData = async () => {
      try {
        const customerResponse = await axios.get(
          "https://localhost:7181/api/customers"
        );
        const employeeResponse = await axios.get(
          "https://localhost:7181/api/employees"
        );
        const serviceResponse = await axios.get(
          "https://localhost:7181/api/services"
        );
        setCustomers(customerResponse.data);
        setEmployees(employeeResponse.data);
        setServices(serviceResponse.data);
      } catch (error) {
        console.error("Error fetching data:", error);
      }
    };

    fetchData();
  }, []);

  const handleCustomerChange = async (e) => {
    const customerId = e.target.value;
    setFormData({
      ...formData,
      customerId: customerId,
    });

    try {
      const customerResponse = await axios.get(
        `https://localhost:7181/api/customers/${customerId}`
      );
      const customer = customerResponse.data;

      if (customer.isCompany) {
        setCompanyName(customer.companyName);
        setCustomerType("Företag");
      } else {
        setCustomerType("Privat");
        setCompanyName("");
      }
    } catch (error) {
      console.error("Error fetching customer data:", error);
    }
  };

  const handleChange = (e) => {
    const { name, value } = e.target;
    setFormData({
      ...formData,
      [name]: value,
    });
  };

  const handleSubmit = async (e) => {
    e.preventDefault();

    const newProject = {
      ...formData,
      customerType: customerType,
      companyName: companyName,
    };

    try {
      const response = await axios.post(
        "https://localhost:7181/api/projects",
        newProject,
        {
          headers: {
            "Content-Type": "application/json",
          },
        }
      );

      console.log("Project added:", response.data);
      setMessage("Projektet har registrerats!");

      setFormData({
        title: "",
        description: "",
        startDate: "",
        endDate: "",
        customerId: "",
        leadEmployeeId: "",
        statusTypeId: "",
        serviceId: "",
      });

      setCompanyName("");
      setCustomerType("Privat");
    } catch (error) {
      console.error(
        "Error adding project:",
        error.response ? error.response.data : error.message
      );
      setMessage("Något gick fel. Försök igen senare.");
    }
  };

  return (
    <div>
      <h3 className="text-center">Projektregistrering</h3>
      {message && <div style={{ marginTop: "20px", color: "green", textAlign: "center" }}>{message}</div>}
      <form onSubmit={handleSubmit}>
        <div className="mb-3">
          <label htmlFor="title" className="form-label">
            Titel
          </label>
          <input
            type="text"
            className="form-control"
            id="title"
            name="title"
            value={formData.title}
            onChange={handleChange}
            required
          />
        </div>
        <div className="mb-3">
          <label htmlFor="description" className="form-label">
            Beskrivning
          </label>
          <textarea
            className="form-control"
            id="description"
            name="description"
            value={formData.description}
            onChange={handleChange}
            required
          />
        </div>
        <div className="mb-3">
          <label htmlFor="startDate" className="form-label">
            Startdatum
          </label>
          <input
            type="date"
            className="form-control"
            id="startDate"
            name="startDate"
            value={formData.startDate}
            onChange={handleChange}
            required
          />
        </div>
        <div className="mb-3">
          <label htmlFor="endDate" className="form-label">
            Slutdatum
          </label>
          <input
            type="date"
            className="form-control"
            id="endDate"
            name="endDate"
            value={formData.endDate}
            onChange={handleChange}
            required
          />
        </div>

        <div className="mb-3">
          <label htmlFor="customerId" className="form-label">
            Kund
          </label>
          <select
            id="customerId"
            name="customerId"
            className="form-select"
            value={formData.customerId}
            onChange={handleCustomerChange}
            required
          >
            <option value="">Välj</option>
            {customers.map((customer) => (
              <option key={customer.id} value={customer.id}>
                {customer.firstName} {customer.lastName}
              </option>
            ))}
          </select>

          <div className="mt-2">
            {formData.customerId === "" ? (
              <span className="text-muted">* Väntar på kundsnamn</span>
            ) : customerType === "Företag" ? (
              <span className="text-muted">{`* Företagskund`}</span>
            ) : customerType === "Privat" ? (
              <span className="text-muted">{`* Privatkund`}</span>
            ) : null}
          </div>
        </div>

        <div className="mb-3">
          <label htmlFor="leadEmployeeId" className="form-label">
            Ledande Anställd
          </label>
          <select
            id="leadEmployeeId"
            name="leadEmployeeId"
            className="form-select"
            value={formData.leadEmployeeId}
            onChange={handleChange}
            required
          >
            <option value="">Välj</option>
            {employees.map((employee) => (
              <option key={employee.id} value={employee.id}>
                {employee.firstName} {employee.lastName}
              </option>
            ))}
          </select>
        </div>

        <div className="mb-3">
          <label htmlFor="serviceId" className="form-label">
            Tjänst
          </label>
          <select
            id="serviceId"
            name="serviceId"
            className="form-select"
            value={formData.serviceId}
            onChange={handleChange}
            required
          >
            <option value="">Välj</option>
            {services.map((service) => (
              <option key={service.id} value={service.id}>
                {service.serviceName}
              </option>
            ))}
          </select>
        </div>

        <div className="mb-3">
          <label htmlFor="statusTypeId" className="form-label">
            Status
          </label>
          <select
            id="statusTypeId"
            name="statusTypeId"
            className="form-select"
            value={formData.statusTypeId}
            onChange={handleChange}
            required
          >
            <option value="">Välj</option>
            <option value="1">Ej Påbörjad</option>
            <option value="2">Påbörjad</option>
            <option value="3">Avslutat</option>
          </select>
        </div>

        <button type="submit" className="btn btn-primary w-100">
          Spara
        </button>
      </form>
    </div>
  );
};

export default AddProject;
