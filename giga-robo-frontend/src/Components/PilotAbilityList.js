import React from 'react';
import PilotAbility from './PilotAbility';
import "./components.css"
import { Card, CardHeader } from 'reactstrap';


export default function PilotAbilityList({pilotAbilities}) {
  return (
    <Card>
        <CardHeader>Pilot Abilites</CardHeader>
    <div className="scrollmenu">
    {pilotAbilities.map((pilotAbility) => (
        <PilotAbility pilotAbility={pilotAbility} key={pilotAbility.id} />
    )
    )}
    </div>
    </Card>
  )
}

