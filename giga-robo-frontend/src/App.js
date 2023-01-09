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
import PilotCardPopOut from "./Components/PilotCardPopOut";
import RobotAbilityPopOut from "./Components/RobotAbilityPopOut";
import PilotAbilityPopOut from "./Components/PilotAbilityPopOut";
import ToggleSwitch from "./Components/ToggleSwitch";

export default function App() {

  //Start off the build we want to make with this initial "null" object. We expect everything in it to change.  
const initialBuild = Object.freeze(
  {
    creator: "Test Creator",
    name: "Test Build Name",
    chosenRobot: null,
    chosenPilot: null,
    robotCardList: null,
    pilotCardList: null,
    chosenPilotAbility: null,
    robotAbilityList: null,
  }); 

const [robots, setRobots] = useState([]);
const [pilots, setPilots] = useState([]);
const [pilotAbilities, setPilotAbilities] = useState([]);
const [robotAbilities, setRobotAbilities] = useState([]);
const [pilotCards, setPilotCards] = useState([]);
const [robotCards, setRobotCards] = useState([]);
let[inputBuild, setBuild] = useState(initialBuild); //Not sure the best way to implament this funciton
let[chosenRobot, setChosenRobot] = useState(0);
let[chosenPilot, setChosenPilot] = useState(0);
let[showSelectedRobotCards, setShowSelectedRobotCards] = useState(false);
let[showSelectedPilotCards, setShowSelectedPilotCards] = useState(false);
let[mouseOverRobotCard, setMouseOverRobotCard] = useState(0);
let[mouseOverPilotCard, setMouseOverPilotCard] = useState(0);
let[mouseOverRobotAbility, setMouseOverRobotAbility] = useState(0);
let[mouseOverPilotAbility, setMouseOverPilotAbility] = useState(0);
let[showRobotCardPop, setShowRobotCardPop] = useState(false);
let[showPilotCardPop, setShowPilotCardPop] = useState(false);
let[showRobotAbilityPop, setShowRobotAbilityPop] = useState(false);
let[showPilotAbilityPop, setShowPilotAbilityPop] = useState(false);
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
    if(showSelectedRobotCards)
    {
      return robotCard.selected === true;
    }else
    {
      return robotCard.robotId === chosenRobot;
    }
    
  }else
  {
    return robotCard;
  } 
});

let filteredPilotCards = pilotCards.filter((pilotCard) => {
  if(chosenPilot !== 0)
  {
    if(showSelectedPilotCards)
    {
      return pilotCard.selected === true;
    }else
    {
      return pilotCard.pilotId === chosenPilot;
    }
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
    //we also want to add this selection to the data structure we want to send back to the database.  
  }

  const selectRobot = async (robotId) => 
  {
    console.log(robotId);
    setChosenRobot(robotId);
    //This is where we want to trigger a filter in our other apps. 
    //we also want to add this selection to the data structure we want to send back to the database. 
  }

  const filterRobotCardClickHander = async() =>
  {
    setShowSelectedRobotCards(!showSelectedRobotCards);
    //console.log("Card Selection filter is: ");
    //console.log(showSelectedRobotCards);

  }

  const filterPilotCardClickHander = async() =>
  {
    setShowSelectedPilotCards(!showSelectedPilotCards);
    //console.log("Pilot Cards Filtered");
    //console.log(showSelectedPilotCards);
  }

  const selectRobotCard = async (robotCard) => 
  {
    //console.log(robotCard);
    //console.log("this robot card has been selected");
    if(robotCard.selected == false || robotCard.selected == null )
    {
      robotCard.selected = true;
    }else
    {
      robotCard.selected = false;
    }
    
    //Here, we want to make a border around the card, and add it to our deck for submission. 
  }

  const selectPilotCard = async (pilotCard) => 
  {
    //console.log(robotCard);
    //console.log("this robot card has been selected");
    if(pilotCard.selected == false || pilotCard.selected == null )
    {
      pilotCard.selected = true;
    }else
    {
      pilotCard.selected = false;
    }
    //Here, we want to make a border around the card, and add it to our deck for submission. 
  }

  const mouseOverRobotCardFunc = async (robotCard) =>
  {
    //console.log(robotCard);
    //console.log("mouse is in");
    setShowRobotCardPop(true);
    setMouseOverRobotCard(robotCard);
  }

  const mouseOutRobotCardFunc = () =>
  {
    //console.log("mouse is out");
    setShowRobotCardPop(false);
  }

  const mouseOverPilotCardFunc = async (pilotCard) =>
  {
    setShowPilotCardPop(true);
    setMouseOverPilotCard(pilotCard);
  }

  const mouseOutPilotCardFunc = () =>
  {
    //console.log("mouse is out");
    setShowPilotCardPop(false);
  }

  const mouseOverRobotAbilityFunc = async (robotAbility) =>
  {
    //console.log(robotCard);
    //console.log("mouse is in");
    setShowRobotAbilityPop(true);
    setMouseOverRobotAbility(robotAbility);
  }

  const mouseOutRobotAbilityFunc = () =>
  {
    //console.log("mouse is out");
    setShowRobotAbilityPop(false);
  }

  const mouseOverPilotAbilityFunc = async (pilotAbility) =>
  {
    setShowPilotAbilityPop(true);
    setMouseOverPilotAbility(pilotAbility);
  }

  const mouseOutPilotAbilityFunc = () =>
  {
    //console.log("mouse is out");
    setShowPilotAbilityPop(false);
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
            {robotAbilities.length > 0 ? (<RobotAbilityList robotAbilities={filteredRobotAbilities} robotAbilityMouseEnter={mouseOverRobotAbilityFunc}
            robotAbilityMouseLeave={mouseOutRobotAbilityFunc} robotMouseMove={mouseMove}/>) : ('No Robot Abilities from server')}
          </Col>
          <Col>
            {pilotAbilities.length > 0 ? (<PilotAbilityList pilotAbilities={filteredPilotAbilities} pilotAbilityMouseEnter={mouseOverPilotAbilityFunc}
            pilotAbilityMouseLeave={mouseOutPilotAbilityFunc} pilotMouseMove={mouseMove} />) : ('No Pilot Abilities from server')}
          </Col>
        </Row>
        <Row className="p-2">
          <Col>
            {robotCards.length > 0 ? (<RobotCardList robotCards={filteredRobotCards} robotCardMouseEnter={mouseOverRobotCardFunc} 
            robotCardMouseLeave={mouseOutRobotCardFunc} robotMouseMove={mouseMove} robotCardSelectded={selectRobotCard} robotCardFilterToggleClick={filterRobotCardClickHander}/>) : ('No Robot Cards from server')}
          </Col>
          <Col>
            {pilotCards.length > 0 ? (<PilotCardList pilotCards={filteredPilotCards} pilotCardMouseEnter={mouseOverPilotCardFunc}
            pilotCardMouseLeave={mouseOutPilotCardFunc} pilotMouseMove={mouseMove} pilotCardSelected={selectPilotCard} pilotCardFilterToggleClick={filterPilotCardClickHander} />) : ('No Pilot Cards from server')}
          </Col>
        </Row>      
          {showRobotCardPop === true ? (<RobotCardPopOut robotCard={mouseOverRobotCard} mouseCoords={MousePosition}/>) : (<></>)}
          {showPilotCardPop === true ? (<PilotCardPopOut pilotCard={mouseOverPilotCard} mouseCoords={MousePosition}/>) : (<></>)}
          {showRobotAbilityPop === true ? (<RobotAbilityPopOut robotAbility={mouseOverRobotAbility} mouseCoords={MousePosition}/>) : (<></>)}
          {showPilotAbilityPop === true ? (<PilotAbilityPopOut pilotAbility={mouseOverPilotAbility} mouseCoords={MousePosition}/>) : (<></>)}








        <h3>Master To-Do List</h3>
        <p>This will get updated when major changes happen, and serves as a roadmap of what needs to be done. When things are more functional, this will live in the readme on github</p>
        <h4>Site Functionallity</h4>
        <ul>
          <li><del>Make Robot Buttons</del></li>
          <li><del>Make Pilot Buttons</del></li>
          <li><del>Get Abilities and cards to show up when buttons are pressed</del></li>
          <li><del>Create User Build Section</del>We are no longer creating a "User Builds" section, now we just highlight the cards when they are in the build</li>
          <li><del>Highlight cards and abilities when clicked</del></li>
          <li>make a toggle button that filters between all cards/abilities, and only cards/abilites in build</li>
          <li>Make abilities and cards get added to a user build section when clicked</li>
          <li>save completed builds in database</li>
          <li><del>Add tool-tip style card descriptions, netrunner db style</del></li>
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
