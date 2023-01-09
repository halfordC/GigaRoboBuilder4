import React from 'react';
import RobotAbility from './RobotAbility';
import "./components.css"
import { Card, CardHeader } from 'reactstrap';
import ToggleSwitch from './ToggleSwitch';


export default function RobotAbilityList({robotAbilities, robotAbilityMouseEnter, robotAbilityMouseLeave, robotMouseMove}) {
  return (
    <Card>
        <CardHeader>Robot Abilites</CardHeader>
    <div className="scrollmenu">
    {robotAbilities.map((robotAbility) => (
        <RobotAbility robotAbility={robotAbility} key={robotAbility.id} onMouseEnterFunc={robotAbilityMouseEnter} robotAbilityMouseLeave={robotAbilityMouseLeave} mouseMove={robotMouseMove}/>
    )
    )}
    </div>
    </Card>
  )
}

