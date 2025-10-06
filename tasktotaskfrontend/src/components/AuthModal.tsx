import * as React from "react";
import TextField from "@mui/material/TextField";
import Button from "@mui/material/Button";
import Dialog from "@mui/material/Dialog";
import DialogActions from "@mui/material/DialogActions";
import DialogContent from "@mui/material/DialogContent";
import DialogTitle from "@mui/material/DialogTitle";

interface AuthModalProps {
    open: boolean;
    onClose: () => void;
}

export default function AuthModal({ open, onClose }: AuthModalProps) {
    const handleSubmit = (event: React.FormEvent<HTMLFormElement>) => {
        event.preventDefault();
        const formData = new FormData(event.currentTarget);
        const formJson = Object.fromEntries((formData as any).entries());
        const email = formJson.email;
        console.log(email);
        onClose();
    };

    return (
        <Dialog open={open} onClose={onClose}>
            <DialogTitle>Вход / Регистрация</DialogTitle>
            <DialogContent>
                <form onSubmit={handleSubmit} id="auth-form">
                    <TextField
                        autoFocus
                        required
                        margin="dense"
                        name="email"
                        label="Email"
                        type="email"
                        fullWidth
                        variant="standard"
                    />
                </form>
            </DialogContent>
            <DialogActions>
                <Button onClick={onClose}>
                    Отмена
                </Button>
                <Button type="submit" form="auth-form">
                    Войти
                </Button>
            </DialogActions>
        </Dialog>
    );
}
