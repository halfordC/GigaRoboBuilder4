import React from 'react'
import PilotCard from './PilotCard';
import "./components.css"
import { Card, CardHeader } from 'reactstrap';

const PilotCardList = ({pilotCards}) => {
  return (
    <Card>
        <CardHeader>Pilot Cards</CardHeader>
    <div className="scrollmenuRobotCards">
        {pilotCards.map((pilotCard) => (
            <PilotCard pilotCard={pilotCard} key={pilotCard.id} />
        ))}
    </div>

    </Card>

  )
}

export default PilotCardList
