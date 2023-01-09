import React from 'react';
import RobotCard from './RobotCard';
import "./components.css"
import { Card, CardHeader, Col, Row, Container } from 'reactstrap';
import ToggleSwitch from './ToggleSwitch';


export default function RobotCardList({robotCards, robotCardMouseEnter, robotCardMouseLeave, robotMouseMove, robotCardSelectded, robotCardFilterToggleClick}) {
  return (
    <Card>
      <CardHeader>
          <Container>
            <Row className="d-flex align-items-center justify-content-center">
              <Col>
                <div>Robot Cards</div>
              </Col>
              <Col>
                {<ToggleSwitch className="d-flex align-items-center" label="In Build" filterToggleClick={robotCardFilterToggleClick}/>}
              </Col>
            </Row>
          </Container>
        </CardHeader>
    <div className="scrollmenuRobotCards">
    {robotCards.map((robotCard) => (
        <RobotCard robotCard={robotCard} key={robotCard.id} onMouseEnterFunc={robotCardMouseEnter} robotCardMouseLeave={robotCardMouseLeave} 
        mouseMove={robotMouseMove} robotCardSelection={robotCardSelectded}/>
    )
    )}
    </div>
    </Card>
  )
}
