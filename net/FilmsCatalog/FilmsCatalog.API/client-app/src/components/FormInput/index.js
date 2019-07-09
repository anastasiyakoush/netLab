import React from "react"
import { withStyles } from "@material-ui/styles"
import { TextField } from "@material-ui/core"
import styles from "./styles"

const FormInput = ({ input, label, type, classes, meta: { touched, error } }) => {
    return (
        <div className={classes.container}>
            <TextField
                {...input}
                variant="outlined"
                fullWidth
                type={type}
                label={label}
                name={input.name}
                className={classes.input}
                error={!!(touched && error)}
                helperText={touched && error}
            />

        </div>
    )
}
export default withStyles(styles)(FormInput);