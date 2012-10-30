class CreateVideoLangues < ActiveRecord::Migration
  def change
    create_table :video_langues do |t|

      t.timestamps
    end
  end
end
