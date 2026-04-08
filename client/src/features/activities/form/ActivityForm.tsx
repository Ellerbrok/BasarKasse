import { Box, Button, Paper, TextField, Typography } from "@mui/material";
import { SubmitEvent } from "react";

type Props = {
    closeForm: () => void
    submitForm: (activity: Activity) => void
    activity?: Activity
}

export default function ActivityForm({ closeForm, submitForm, activity }: Props) {

    const handleSubmit = (event: SubmitEvent) => {
        event.preventDefault();

        const formData = new FormData(event.currentTarget as HTMLFormElement);
        const data: { [key: string]: FormDataEntryValue } = {}
        formData.forEach((value, key) => {
            data[key] = value
        });

        if(activity) {
            data.id = activity.id
        }

        submitForm(data as Activity)
    }

  return (
    <Paper sx={{padding: 1.5}}>
        <Typography variant="h5" gutterBottom color="primary">
            {activity ? 'Edit activity' : 'Create activity'}
        </Typography>
        <Box component="form" onSubmit={handleSubmit} display="flex" flexDirection="column" gap={3}>
            <TextField name="name" label="Title" defaultValue={activity?.name || ''}/>
            <TextField name="date" label="Date" type="date" defaultValue={activity?.date || ''}/>
            <Box display="flex" justifyContent="end" gap={3}>
                <Button color="inherit" onClick={closeForm}>Cancel</Button>
                <Button type="submit" color="success" variant="contained">Submit</Button>
            </Box>
        </Box>
    </Paper>
  )
}
 