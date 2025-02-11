import React, { useState, useEffect } from 'react';
import axios from 'axios';
import { Link } from 'react-router-dom';

const ProjectPage = () => {
  const [projects, setProjects] = useState([]);
  const [loading, setLoading] = useState(true);

  const apiUrl = 'https://localhost:7181/api/projects';

  const fetchProjectsWithDetails = async () => {
    setLoading(true);
    try {
      const response = await axios.get(`${apiUrl}/more-details`);
      setProjects(response.data);
      setLoading(false);
    } catch (error) {
      console.error('Error fetching detailed projects:', error);
      setLoading(false);
    }
  };

  const handleDelete = async (projectId) => {
    if (window.confirm('Är du säker på att du vill ta bort det här projektet?')) {
      try {
        await axios.delete(`${apiUrl}/${projectId}`);
        setProjects(projects.filter((project) => project.id !== projectId));
      } catch (error) {
        console.error('Error deleting the project:', error);
      }
    }
  };

  useEffect(() => {
    fetchProjectsWithDetails();
  }, []);

  if (loading) {
    return <div>Loading...</div>;
  }

  return (
    <div className="container mt-5">
      <div className="d-flex justify-content-between align-items-center">
        <h2>Alla Projekt</h2>
        <Link to="/" className="btn btn-dark" style={{ fontSize: '20px', width: '200px' }}>
          Home
        </Link>
      </div>

      <table className="table mt-4">
        <thead>
          <tr>
            <th>Projektets namn</th>
            <th>Beskrivning</th>
            <th>Projektledare</th>
            <th></th>
          </tr>
        </thead>
        <tbody>
          {projects.map((project) => (
            <tr key={project.id}>
              <td>{project.title}</td>
              <td>{project.description}</td>
              <td>{project.leadEmployee ? `${project.leadEmployee.firstName} ${project.leadEmployee.lastName}` : "N/A"}</td>
              <td>
                <Link to={`/update-project/${project.id}`} className="btn btn-info btn-sm mx-1">
                  Update
                </Link>
                <button
                  className="btn btn-danger btn-sm"
                  onClick={() => handleDelete(project.id)}
                >
                  Delete
                </button>
              </td>
            </tr>
          ))}
        </tbody>
      </table>
    </div>
  );
};

export default ProjectPage;
