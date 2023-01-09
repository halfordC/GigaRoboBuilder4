import { Card, CardHeader } from "reactstrap"

const RobotAbilityPopOut = ({robotAbility, mouseCoords}) => {
  return (
    <div style={{position: 'absolute', left: mouseCoords[0], top: mouseCoords[1]}}>
        <Card>
            <CardHeader><h5>{robotAbility.name}</h5></CardHeader>
            <p>{robotAbility.rules}</p>
        </Card>
    </div>
  )
}

export default RobotAbilityPopOut