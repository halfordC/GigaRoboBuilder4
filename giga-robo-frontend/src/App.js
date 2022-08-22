import React, {cloneElement, useState} from "react";
import Constants from "./utilities/Constants";


export default function App() {
const [robots, setRobots] = useState([]);

  function getRobots() {
    const url = Constants.API_URL_GET_ALL_ROBOTS;
    fetch(url, {
      method: 'GET'
    })
    .then(response => response.json())
    .then(robotsFromServer => {
      console.log(robotsFromServer);
      setRobots(robotsFromServer);
    })
    .catch((error) => {
      console.log(error);
      alert(error);
    });
    
  }

  return (
    <div className="container">
      <div className="row min-vh-100 ">
        <div className="col d-flex flex-column justify-content-center align-items-center">
          <div>
            <h1>List of Robots</h1>
          </div>
          <div className="mt-5">
            <button onClick={getRobots} className='btn btn-dark btn-lg w-100'>Get Robots From Server</button>
            <button onClick={() => {}} className='btn btn-secondary btn-lg w-100 mt-4'>Create new Robot</button>
          </div>          

          {robots.length > 0 && renderRobots()}
        </div>
      </div>
    </div>
  );



function renderRobots()
{
  return (
    <div className="table-responsive mt-5">
      <table className="table table-bordered border-dark">
        <thead>
          <tr>
            <th scope='col'>Robot Id (PK)</th>
            <th scope='col'>Robot Name</th>
            <th scope='col'>Robot Speed</th>
            <th scope='col'>Robot Defence</th>
            <th scope='col'>Robot Max Armour</th>
          </tr>
        </thead>
        <tbody>
        {robots.map((robot) => (
          <tr key={robot.id}>
            <th scope="row">{robot.id}</th>
            <td>{robot.name}</td>
            <td>{robot.speed}</td>
            <td>{robot.defence}</td>
            <td>{robot.maxArmour}</td>
          </tr>
        ))}
        </tbody>
      </table>



      <button onClick={() => setRobots([])} className='btn btn-dark brn-lg w-100'>Empty Robot Array</button>
    </div>

  );
}
}
