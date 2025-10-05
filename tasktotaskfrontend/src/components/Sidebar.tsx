"use client";
import { ReactNode, useState } from "react";
import Link from "next/link";
import Image from "next/image";
import { usePathname } from "next/navigation";
import Button from "@mui/material/Button";
import ArrowForwardIosOutlinedIcon from '@mui/icons-material/ArrowForwardIosOutlined';
import ArrowBackIosOutlinedIcon from '@mui/icons-material/ArrowBackIosOutlined';
import HomeIcon from "@mui/icons-material/Home";
import TaskIcon from "@mui/icons-material/Task";
import NoteIcon from "@mui/icons-material/Note";
import SettingsIcon from "@mui/icons-material/Settings";

type NavItem = {
    label: string;
    href: string;
    icon: ReactNode;
};

const navItems: NavItem[] = [
    { label: "Home", href: "/", icon: <HomeIcon /> },
    { label: "Tasks", href: "/tasks", icon: <TaskIcon /> },
    { label: "Notes", href: "/notes", icon: <NoteIcon /> },
    { label: "Settings", href: "/settings", icon: <SettingsIcon /> },
];

export default function Sidebar() {
    const [isCollapsed, setIsCollapsed] = useState(false);
    const pathname = usePathname();
    return (
        <aside className={`h-screen bg-gray-900 text-white flex flex-col transition-all duration-300 ${isCollapsed ? "w-20" : "w-64"}`}>
            <div className="h-20 border-b border-gray-700 flex items-center gap-2 px-4">
                <Image src="/logo.svg" alt="logo" width={48} height={48} />
                {!isCollapsed && <span className="text-xl font-bold">TaskToTask</span>}
            </div>
            <nav className="flex-1 p-2 space-y-2">
                {navItems.map((item) => {
                    const isActive = pathname === item.href;
                    return (
                        <Link
                            key={item.href}
                            href={item.href}
                            className={`flex items-center px-4 py-2 rounded-md transition 
                                ${isActive ? "bg-gray-700" : "hover:bg-gray-800"}`}
                        >
                            {item.icon}
                            <span
                                className={`ml-2 transition-all duration-300 overflow-hidden whitespace-nowrap 
                                    ${isCollapsed ? "w-0 opacity-0" : "w-auto opacity-100"}`}
                            >
                                {item.label}
                            </span>
                        </Link>
                    );
                })}
            </nav>
            <Button
                variant="outlined"
                className="flex items-center justify-center h-12 p-0"
                onClick={() => setIsCollapsed(!isCollapsed)}
            >
                {(isCollapsed) ? <ArrowForwardIosOutlinedIcon /> : <ArrowBackIosOutlinedIcon />}
            </Button>
        </aside>
    );
}