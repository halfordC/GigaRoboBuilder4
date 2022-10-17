import React, {cloneElement, useEffect, useState} from "react";
import RobotPicker from "./Components/RobotPicker";
import Constants from "./utilities/Constants";
import PilotPicker from "./Components/PilotPicker";
import PilotAbilityList from "./Components/PilotAbilityList";
import RobotAbilityList from "./Components/RobotAbilityList";
import { Container, Row, Col } from "reactstrap";
import RobotCardList from "./Components/RobotCardList";
import PilotCardList from "./Components/PilotCardList";
import RobotCardPopOut from "./Components/RobotCardPopOut";

export default function App() {
const [robots, setRobots] = useState([]);
const [pilots, setPilots] = useState([]);
const [pilotAbilities, setPilotAbilities] = useState([]);
const [robotAbilities, setRobotAbilities] = useState([]);
const [pilotCards, setPilotCards] = useState([]);
const [robotCards, setRobotCards] = useState([]);
let[chosenRobot, setChosenRobot] = useState(0);
let[chosenPilot, setChosenPilot] = useState(0);
let[mouseOverRobotCard, setMouseOverRobotCard] = useState(0);
let[showRobotCardPop, setShowRobotCardPop] = useState(false);
let[MousePosition, setMousePosition] = useState([0,0]);

let filteredRobotAbilities = robotAbilities.filter((robotAbility) => {
  if(chosenRobot !== 0)//if we have clicked a robot
  {
    return robotAbility.robotId === chosenRobot;
  }else
  {
    return robotAbility;
  } 
});

let filteredPilotAbilities = pilotAbilities.filter((pilotAbility) => {
  if(chosenPilot !== 0)
  {
    return pilotAbility.pilotId === chosenPilot;
  }else
  {
    return pilotAbility;
  }
});

let filteredRobotCards = robotCards.filter((robotCard) => {
  if(chosenRobot !== 0)//if we have clicked a robot
  {
    return robotCard.robotId === chosenRobot;
  }else
  {
    return robotCard;
  } 
});

let filteredPilotCards = pilotCards.filter((pilotCard) => {
  if(chosenPilot !== 0)
  {
    return pilotCard.pilotId === chosenPilot;
  }else
  {
    return pilotCard;
  }
});




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

    const getPilotAbilities = async () =>
    {
      const pilotAbilitiesFromServer = await fetchPilotAbilities();
      console.log(pilotAbilitiesFromServer);
      setPilotAbilities(pilotAbilitiesFromServer);
    }

    const getRobotAbilities = async () =>
    {
      const robotAbilitiesFromServer = await fetchRobotAbilities();
      console.log(robotAbilitiesFromServer);
      setRobotAbilities(robotAbilitiesFromServer);
    }

    const getRobotCards = async () =>
    {
      const robotCardsFromServer = await fetchRobotCards();
      console.log(robotCardsFromServer);
      setRobotCards(robotCardsFromServer);
    }

    const getPilotCards = async () =>
    {
      const pilotCardsFromServer = await fetchPilotCards();
      console.log(pilotCardsFromServer);
      setPilotCards(pilotCardsFromServer);
      
    }

    getRobots();
    getPilots();
    getPilotAbilities();
    getRobotAbilities();
    getRobotCards();
    getPilotCards();
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

  const fetchPilotAbilities= async() => {
    const url = Constants.API_URL_GET_ALL_PILOT_ABILITIES;
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

  //this function seems unessasary, now that we're grabbing all pilots at startup, and filtering to what we need. 
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

  const fetchRobotAbilities= async() => {
    const url = Constants.API_URL_GET_ALL_ROBOT_ABILITIES;
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

  const fetchRobotCards= async() => {
    const url = Constants.API_URL_GET_ALL_ROBOT_CARDS;
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

  const fetchPilotCards= async() => {
    const url = Constants.API_URL_GET_ALL_PILOT_CARDS;
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




  const selectPilot = async (pilotId) => 
  {
    console.log(pilotId);
    setChosenPilot(pilotId);
    //This is where we want to trigger a filter in our other apps. 
  }

  const selectRobot = async (robotId) => 
  {
    console.log(robotId);
    setChosenRobot(robotId);
    
    //This is where we want to trigger a filter in our other apps. 
  }

  const mouseOverRobotCardFunc = async (robotCard) =>
  {
    console.log(robotCard);
    console.log("mouse is in");
    setShowRobotCardPop(true);
    setMouseOverRobotCard(robotCard);
  }

  const mouseOutRobotCardFunc = () =>
  {
    console.log("mouse is out");
    setShowRobotCardPop(false);
  }

  function mouseMove(e)
  {
    setMousePosition([e.pageX+5, e.pageY+5]);
  }

  return (
    <div>
      <Container className="gap-3">
        <Row className="p-2">
            <h1>Choose your Robot</h1>
        </Row>
        <Row className="p-2">
          {robots.length > 0 ? (<RobotPicker robots={robots} robotSelected={selectRobot}/>) : ('No Robots from server')}
        </Row>
        <Row className="p-2">
            <h1>Choose your Pilot</h1>
        </Row>        
          {pilots.length > 0 ? (<PilotPicker pilots={pilots} pilotSelected={selectPilot}/>) : ('No Pilots from server')}        
        <Row className="p-2">  
          <Col>
            {robotAbilities.length > 0 ? (<RobotAbilityList robotAbilities={filteredRobotAbilities}/>) : ('No Robot Abilities from server')}
          </Col>
          <Col>
            {pilotAbilities.length > 0 ? (<PilotAbilityList pilotAbilities={filteredPilotAbilities}/>) : ('No Pilot Abilities from server')}
          </Col>
        </Row>
        <Row className="p-2">
          <Col>
            {robotCards.length > 0 ? (<RobotCardList robotCards={filteredRobotCards} robotCardMouseEnter={mouseOverRobotCardFunc} 
            robotCardMouseLeave={mouseOutRobotCardFunc} robotMouseMove={mouseMove} />) : ('No Robot Cards from server')}
          </Col>
          <Col>
            {pilotCards.length > 0 ? (<PilotCardList pilotCards={filteredPilotCards}/>) : ('No Pilot Cards from server')}
          </Col>
        </Row>
          {showRobotCardPop === true ? (<RobotCardPopOut robotCard={mouseOverRobotCard} mouseCoords={MousePosition}/>) : (<></>)}








        <h3>Master To-Do List</h3>
        <p>This will get updated when major changes happen, and serves as a roadmap of what needs to be done. When things are more functional, this will live in the readme on github</p>
        <h4>Site Functionallity</h4>
        <ul>
          <li><del>Make Robot Buttons</del></li>
          <li><del>Make Pilot Buttons</del></li>
          <li><del>Get Abilities and cards to show up when buttons are pressed</del></li>
          <li>Create User Build Section</li>
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
        </Container>
    </div>

  );
}
