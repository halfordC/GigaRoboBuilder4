import React, {cloneElement, useEffect, useState} from "react";
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
          </div>          
          {robots.length > 0 && renderRobots()}
        </div>
      </div>
      <div>
        <h3>Master To-Do List</h3>
        <p>This will get updated when major changes happen, and serves as a roadmap of what needs to be done. When things are more functional, this will live in the readme on github</p>
        <h4>Site Functionallity</h4>
        <ul>
          <li>Make Robot Buttons</li>
          <li>Make Pilot Buttons</li>
          <li>Get Abilities and cards to show up when buttons are pressed</li>
          <li>Make abilities and cards get added to a user build section when clicked</li>
          <li>save completed builds in database</li>
          <li>Add tool-tip style card descriptions, netrunner db style</li>
          <li>create client side validation of builds, so that we don't create builds that break the rules</li>
          <li>add a build list page, one for all builds, and one for builds from current user</li>
          <li>create user / password functionality</li>
          <li>Find a good react or C# module to handle all the hairy authentication stuff for us</li>
          <li>Maybe add more user / social functions, like favoriting builds, and adding comments? Ask Alex.</li>
        </ul>
        <h4>Style and Design</h4>
        <ul>
          <li>Make a figma layout of how the site should acutally look</li>
          <li>make everything look cool</li>
          <li>Add Css animations to stuff</li>
          <li>Add build statics and charts. Card cost histograms, type histograms, ect</li>
        </ul>
      </div>
    </div>
  );



function renderRobots()
{
  return (
    <div>
      {robots.map((robot) => (
              <button className='btn btn-primary px-2'>{robot.name}</button>
        ))}
    </div>
  );
}
}
