import React from 'react';
import PilotAbility from './PilotAbility';
import "./components.css"
import { Card, CardHeader } from 'reactstrap';
import ToggleSwitch from './ToggleSwitch';


export default function PilotAbilityList({pilotAbilities, pilotAbilityMouseEnter, pilotAbilityMouseLeave, pilotMouseMove}) {
  return (
    <Card>
        <CardHeader>Pilot Abilites</CardHeader>
    <div className="scrollmenu">
        {pilotAbilities.map((pilotAbility) => (
            <PilotAbility pilotAbility={pilotAbility} key={pilotAbility.id} onMouseEnterFunc={pilotAbilityMouseEnter} pilotAbilityMouseLeave={pilotAbilityMouseLeave} mouseMove={pilotMouseMove}/>
    ))}
    </div>
    </Card>
  )
}

