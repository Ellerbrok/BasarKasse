import { Box, Button, Paper, TextField, Typography } from "@mui/material";
import type { SubmitEvent } from "react";
import { useActivities } from "../../../lib/hooks/useActivities";

type Props = {
    closeForm: () => void
    activity?: Activity
}

export default function ActivityForm({ closeForm, activity }: Props) {
    const {updateActivity, createActivity} = useActivities();

    const handleSubmit = async (event: SubmitEvent) => {
        event.preventDefault();

        const formData = new FormData(event.currentTarget as HTMLFormElement);
        const data: { [key: string]: FormDataEntryValue } = {}
        formData.forEach((value, key) => {
            data[key] = value
        });

        if(activity) {
            data.id = activity.id;
            await updateActivity.mutateAsync(data as Activity);
            closeForm();
        } else {
            await createActivity.mutateAsync(data as Activity);
            closeForm();
        }
    }

  return (
    <Paper sx={{padding: 1.5}}>
        <Typography variant="h5" gutterBottom color="primary">
            {activity ? 'Edit activity' : 'Create activity'}
        </Typography>
        <Box component="form" onSubmit={handleSubmit} display="flex" flexDirection="column" gap={3}>
            <TextField name="name" label="Title" defaultValue={activity?.name || ''}/>
            <TextField name="date" label="Date" type="date" 
                defaultValue={activity?.date 
                    ? new Date(activity.date).toISOString().split('T')[0] 
                    : new Date().toISOString().split('T')[0]}
            />
            <Box display="flex" justifyContent="end" gap={3}>
                <Button color="inherit" onClick={closeForm}>Cancel</Button>
                <Button 
                    type="submit" 
                    color="success" 
                    variant="contained" 
                    loading={updateActivity.isPending || createActivity.isPending}>
                    Submit
                </Button>
            </Box>
        </Box>
    </Paper>
  )
}
 