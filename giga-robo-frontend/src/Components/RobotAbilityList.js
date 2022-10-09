import React from 'react';
import RobotAbility from './RobotAbility';
import "./components.css"
import { Card, CardHeader } from 'reactstrap';


export default function RobotAbilityList({robotAbilities}) {
  return (
    <Card>
        <CardHeader>Robot Abilites</CardHeader>
    <div className="scrollmenu">
    {robotAbilities.map((robotAbility) => (
        <RobotAbility robotAbility={robotAbility} key={robotAbility.id} />
    )
    )}
    </div>
    </Card>
  )
}

