import React, {cloneElement, useEffect, useState} from "react";
import RobotPicker from "./Components/RobotPicker";
import Constants from "./utilities/Constants";
import PilotPicker from "./Components/PilotPicker";


export default function App() {
const [robots, setRobots] = useState([]);
const [pilots, setPilots] = useState([]);
const [pilotAbilities, setPilotAbilities] = useState([]);


  useEffect(() => {
    const getRobots = async () => 
    {
      const robotsFromServer = await fetchRobots();
      console.log(robotsFromServer);
      setRobots(robotsFromServer);
    }

    const getPilots = async () => 
    {
      const pilotsFromServer = await fetchPilots();
      console.log(pilotsFromServer);
      setPilots(pilotsFromServer);
    }

    getRobots();
    getPilots();
  }, [])

  const fetchRobots= async() => {
    const url = Constants.API_URL_GET_ALL_ROBOTS;
    const res = await fetch(url, {
        method: 'GET'
    })
    const data = await res.json()
    .catch((error) => {
      console.log(error);
      alert(error);
    });
    
    return data;
  }

  const fetchPilots= async() => {
    const url = Constants.API_URL_GET_ALL_PILOTS;
    const res = await fetch(url, {
        method: 'GET'
    })
    const data = await res.json()
    .catch((error) => {
      console.log(error);
      alert(error);
    });
    
    return data;
  }

  const fetchPilotAbilitiesByPilot= async(pilotId) => {
    const url = Constants.API_URL_GET_PILOT_ABILITIES_BY_PILOT + "/" + pilotId;
    const res = await fetch(url, {
        method: 'GET'
    })
    const data = await res.json()
    .catch((error) => {
      console.log(error);
      alert(error);
    });
    
    console.log(data);
    setPilotAbilities(data);
  }


  const selectPilot = async (pilotId) => 
  {
    console.log(pilotId);
  }

  return (
    <div className="container">
      <div className="row min-vh-100 ">
        <div className="col d-flex flex-column justify-content-center align-items-center">
          <div>
            <h1>Choose your Robot</h1>
          </div>
          {robots.length > 0 ? (<RobotPicker robots={robots}/>) : ('No Robots from server')}
          <div>
            <h1>Choose your Pilot</h1>
          </div>         
          {pilots.length > 0 ? (<PilotPicker pilots={pilots} pilotSelected={selectPilot}/>) : ('No Pilots from server')}
          <button onClick={() => fetchPilotAbilitiesByPilot(1)}>Test Get Pilot by ID 1</button>
        </div>
          
      </div>







      <div>
        <h3>Master To-Do List</h3>
        <p>This will get updated when major changes happen, and serves as a roadmap of what needs to be done. When things are more functional, this will live in the readme on github</p>
        <h4>Site Functionallity</h4>
        <ul>
          <li><del>Make Robot Buttons</del></li>
          <li><del>Make Pilot Buttons</del></li>
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
}
