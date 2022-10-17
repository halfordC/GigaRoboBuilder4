import React from 'react';
import RobotCard from './RobotCard';
import "./components.css"
import { Card, CardHeader } from 'reactstrap';


export default function RobotCardList({robotCards, robotCardMouseEnter, robotCardMouseLeave, robotMouseMove}) {
  return (
    <Card>
        <CardHeader>Robot Cards</CardHeader>
    <div className="scrollmenuRobotCards">
    {robotCards.map((robotCard) => (
        <RobotCard robotCard={robotCard} key={robotCard.id} onMouseEnterFunc={robotCardMouseEnter} robotCardMouseLeave={robotCardMouseLeave} mouseMove={robotMouseMove} />
    )
    )}
    </div>
    </Card>
  )
}
