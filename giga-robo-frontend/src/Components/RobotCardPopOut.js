import { Card, CardHeader } from "reactstrap"

const RobotCardPopOut = ({robotCard, mouseCoords}) => {
  return (
    <div style={{position: 'absolute', left: mouseCoords[0], top: mouseCoords[1]}}>
        <Card>
            <CardHeader><h5>{robotCard.name}</h5></CardHeader>
            <h5>{robotCard.cardType}</h5>
            <p>{robotCard.rules}</p>
        </Card>

    </div>
  )
}

export default RobotCardPopOut
