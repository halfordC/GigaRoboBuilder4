import { Card, CardHeader } from "reactstrap"

const PilotAbilityPopOut = ({pilotAbility, mouseCoords}) => {
  return (
    <div style={{position: 'absolute', left: mouseCoords[0], top: mouseCoords[1]}}>
        <Card>
            <CardHeader><h5>{pilotAbility.name}</h5></CardHeader>
            <p>{pilotAbility.rules}</p>
        </Card>

    </div>
  )
}

export default PilotAbilityPopOut