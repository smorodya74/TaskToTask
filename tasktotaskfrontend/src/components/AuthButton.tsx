import { Button } from "@mui/material"
import { useState } from "react";
import AuthModal from "./AuthModal";

export default function AuthButton() {
    const [isModalOpen, setModalOpen] = useState(false);
    return (
        <>
            <Button variant="outlined" onClick={() => setModalOpen(true)}>
                Войти
            </Button>
            <AuthModal open={isModalOpen} onClose={() => setModalOpen(false)} />
        </>
    );
}