"use client";

import React from "react";
import AuthButton from "./AuthButton";

export default function Header() {
  return (
    <header className="sticky top-0 h-20 bg-gray-900 flex items-center px-10 z-10 border-b-2 border-gray-700 ">
      <div className="relative ml-auto">
        <AuthButton />
      </div>
    </header>
  );
}
