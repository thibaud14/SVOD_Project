class CreateVideoPeople < ActiveRecord::Migration
  def change
    create_table :video_people do |t|

      t.timestamps
    end
  end
end
