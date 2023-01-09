import { Card, CardHeader } from "reactstrap"

const PilotCardPopOut = ({pilotCard, mouseCoords}) => {
  return (
    <div style={{position: 'absolute', left: mouseCoords[0], top: mouseCoords[1]}}>
        <Card>
            <CardHeader><h5>{pilotCard.name}</h5></CardHeader>
            <h5>{pilotCard.type}</h5>
            <p>{pilotCard.rules}</p>
        </Card>

    </div>
  )
}

export default PilotCardPopOut