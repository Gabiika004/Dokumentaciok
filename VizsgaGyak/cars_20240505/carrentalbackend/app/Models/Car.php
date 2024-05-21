<?php

namespace App\Models;

use Illuminate\Database\Eloquent\Factories\HasFactory;
use Illuminate\Database\Eloquent\Model;

class Car extends Model
{
    use HasFactory;

    public $fillable = ['license_plate_number','brand','model','daily_cost'];

    protected $hidden = ['created_at','updated_at'];
}
