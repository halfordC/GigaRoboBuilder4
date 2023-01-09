import React from 'react'
import PilotCard from './PilotCard';
import "./components.css"
import { Card, CardHeader, Col, Row, Container } from 'reactstrap';
import ToggleSwitch from './ToggleSwitch';

const PilotCardList = ({pilotCards, pilotCardMouseEnter, pilotCardMouseLeave, pilotMouseMove, pilotCardFilterToggleClick, pilotCardSelected}) => {
  return (
    <Card>
      <CardHeader>
        <Container>
          <Row className="d-flex align-items-center justify-content-center">
            <Col>
              <div>Pilot Cards</div>
            </Col>
            <Col>
              {<ToggleSwitch className="d-flex align-items-center" label="PCIn Build" filterToggleClick={pilotCardFilterToggleClick}/>}
            </Col>
          </Row>
        </Container> 
      </CardHeader>
    <div className="scrollmenuRobotCards">
        {pilotCards.map((pilotCard) => (
            <PilotCard pilotCard={pilotCard} key={pilotCard.id} onMouseEnterFunc={pilotCardMouseEnter} pilotCardMouseLeave={pilotCardMouseLeave} 
            mouseMove={pilotMouseMove} pilotCardSelection={pilotCardSelected}/>
        ))}
    </div>

    </Card>

  )
}

export default PilotCardList
