import { Button, Card, CardActions, CardContent, Chip, Typography } from "@mui/material"

type Props = {
    activity: Activity
    selectActivity: (id: string) => void
}

export default function ActivityCard({ activity, selectActivity }: Props) {
  return (
    <Card>
        <CardContent>
            <Typography variant="h5">{activity.name}</Typography>
            <Typography sx={{color: 'text.secondary', mb: 1}}>{activity.date}</Typography>
        </CardContent>
        <CardActions sx={{display: 'flex', justifyContent: 'space-between', pb : 2}}>
            <Chip label={activity.id}  variant="outlined"/>
            <Button size="medium" variant="contained" onClick={() => selectActivity(activity.id)}>View</Button>
        </CardActions>
    </Card>
  )
}
