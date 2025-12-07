package com.github.elitonluiz1989.financemanager

interface Platform {
    val name: String
}

expect fun getPlatform(): Platform